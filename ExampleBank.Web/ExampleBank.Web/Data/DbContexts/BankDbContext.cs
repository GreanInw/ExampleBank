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
            SeedData(modelBuilder);
        }

        private void TablesConfigurations(ModelBuilder builder)
        {
            builder.Entity<BankAccount>(t =>
            {
                t.HasKey(f => new { f.IBAN, f.AccountId });
                t.Property(f => f.BankAccountType)
                 .HasConversion(from => from.ToString()
                    , to => Enum.Parse<BankAccountType>(to));
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

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(new[]
            {
                new Account 
                { 
                    Id = Guid.NewGuid(), 
                    FirstName = "Jon", LastName = "Snow",
                    CreatedBy = "System", ModifiedBy = "System", 
                    CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow,
                    BackAccounts = new List<BankAccount>
                    {
                        new BankAccount 
                        { 
                            IBAN = "NL73INGB2274264198", Amount = 100000,
                            BankAccountType = BankAccountType.Saving,
                            CreatedBy = "System", ModifiedBy = "System",
                            CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow,
                        },
                        new BankAccount 
                        { 
                            IBAN = "NL06INGB4999152932", Amount = 100000,
                            BankAccountType = BankAccountType.CurrentAccount,
                            CreatedBy = "System", ModifiedBy = "System",
                            CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow,
                        },
                    } 
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Aegon", LastName = "Targaryen",
                    CreatedBy = "System", ModifiedBy = "System",
                    CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow,
                    BackAccounts = new List<BankAccount>
                    {
                        new BankAccount
                        {
                            IBAN = "NL76ABNA2376059879", Amount = 500,
                            BankAccountType = BankAccountType.Saving,
                            CreatedBy = "System", ModifiedBy = "System",
                            CreatedDate = DateTime.UtcNow, ModifiedDate = DateTime.UtcNow,
                        }
                    }
                },
            });
        }
    }
}