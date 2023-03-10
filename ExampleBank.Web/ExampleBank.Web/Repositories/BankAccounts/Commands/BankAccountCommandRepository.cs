using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.BankAccounts.Commands
{
    public class BankAccountCommandRepository : CommandRepository<BankAccount, IBankDbContext>, IBankAccountCommandRepository
    {
        public BankAccountCommandRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}