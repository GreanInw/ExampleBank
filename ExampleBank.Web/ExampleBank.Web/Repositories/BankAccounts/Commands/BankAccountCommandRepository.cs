using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Commands;

namespace ExampleBank.Web.Repositories.BankAccounts.Commands
{
    public class BankAccountCommandRepository : CommandRepository<BankAccount, IBankDbContext>, IBankAccountCommandRepository
    {
        public BankAccountCommandRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}