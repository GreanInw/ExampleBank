using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Queries;

namespace ExampleBank.Web.Repositories.Accounts.Queries
{
    public class AccountQueryRepository : QueryRepository<Account, IBankDbContext>, IAccountQueryRepository
    {
        public AccountQueryRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}