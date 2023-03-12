using ExampleBank.Web.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.BackgroundServices
{
    public class AutoMigrationService : IHostedService
    {
        public AutoMigrationService(ILogger<AutoMigrationService> logger, IBankDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        protected ILogger<AutoMigrationService> Logger { get; }
        protected IBankDbContext DbContext { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Start auto migration.");
            try
            {
                await DbContext.Database.MigrateAsync();
                Logger.LogInformation("End auto migration.");
            }
            catch (Exception ex )
            {
                Logger.LogError(ex, ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Auto migration complete.");
            return Task.CompletedTask;
        }
    }
}
