using ExampleBank.Web.Data.TableConfigurations;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Enums;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Data.DbContexts
{
    public class BankDbContext : DbContext, IBankDbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TablesConfigurations(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

        private void TablesConfigurations(ModelBuilder builder)
        {
            builder.Entity<BankAccount>(t =>
            {
                t.HasKey(f => new { f.IBAN, f.AccountId });
            });

            builder.Entity<Transaction>(t =>
            {
                t.Property(f => f.TransactionType)
                 .HasConversion(from => from.ToString()
                    , to => Enum.Parse<TransactionType>(to));
            });
        }

        private void ApplyConfigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuditableConfiguration<BankAccount>());
            builder.ApplyConfiguration(new AuditableConfiguration<Account>());
            builder.ApplyConfiguration(new IBANConfiguration<BankAccount>());
            builder.ApplyConfiguration(new IBANConfiguration<Transaction>());
        }

    }
}