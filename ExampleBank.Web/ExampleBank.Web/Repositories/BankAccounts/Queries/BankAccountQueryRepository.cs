using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Queries;

namespace ExampleBank.Web.Repositories.BankAccounts.Queries
{
    public class BankAccountQueryRepository : QueryRepository<BankAccount, IBankDbContext>, IBankAccountQueryRepository
    {
        public BankAccountQueryRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}