namespace ExampleBank.Web.DependencyInjections
{
    public static class MicorsoftRegisterExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

            return services;
        }

        public static void ConfigurationApplication(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
