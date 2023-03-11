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
            //SeedData(modelBuilder);
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
                    Id = Guid.Parse("5c1ebb1c-ade1-43bd-85bc-977e81cadfc2"),
                    FirstName = "Jon", LastName = "Snow",
                    CreatedBy = "System", ModifiedBy = "System",
                    CreatedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc),
                    ModifiedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc)
                },
                new Account
                {
                    Id = Guid.Parse("8382a5a4-c73f-4314-af3e-699c16fca88e"),
                    FirstName = "Aegon", LastName = "Targaryen",
                    CreatedBy = "System", ModifiedBy = "System",
                    CreatedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc),
                    ModifiedDate = new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc)
                },
            });
        }
    }
}