using ExampleBank.Web.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);
builder.Host.RegisterCompomentWithAutofac(builder.Configuration);

var app = builder.Build();
app.ConfigurationApplication();
app.Run();