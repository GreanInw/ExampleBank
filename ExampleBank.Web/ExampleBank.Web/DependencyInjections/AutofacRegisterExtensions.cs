using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExampleBank.Web.Commons;
using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.UOMs;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.DependencyInjections
{
    public static class AutofacRegisterExtensions
    {
        public static IHostBuilder RegisterCompomentWithAutofac(this IHostBuilder host, IConfiguration configuration)
        {
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterType<BankUnitOfWork>().As<IBankUnitOfWork>().InstancePerLifetimeScope();
                builder.RegisterDbContexts(configuration)
                       .RegisterWithAssembly(CommonInternalConstants.AutoRegisterCompoments.RepositoryName)
                       .RegisterWithAssembly(CommonInternalConstants.AutoRegisterCompoments.ServiceName);
            });
            return host;
        }

        private static ContainerBuilder RegisterDbContexts(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.Register(com =>
            {
                var connection = configuration.GetValue<string>(CommonInternalConstants.ConfigNames.LocalDbName);
                var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>()
                    .UseSqlServer(connection, options =>
                    {
                        options.EnableRetryOnFailure();
                        options.MigrationsAssembly(typeof(BankDbContext).Assembly.GetName().Name);
                    });
                return optionsBuilder.Options;
            }).SingleInstance();

            builder.Register(com =>
            {
                var options = com.Resolve<DbContextOptions<BankDbContext>>();
                return new BankDbContext(options);
            }).As<IBankDbContext>().InstancePerLifetimeScope();
            return builder;
        }

        private static ContainerBuilder RegisterWithAssembly(this ContainerBuilder builder, string name)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(w => w.Name.EndsWith(name))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            return builder;
        }
    }
}