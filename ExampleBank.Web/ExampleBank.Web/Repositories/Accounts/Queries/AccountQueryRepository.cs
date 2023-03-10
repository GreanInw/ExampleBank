using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Queries;

namespace ExampleBank.Web.Repositories.Accounts.Queries
{
    public class AccountQueryRepository : QueryRepository<Account, IBankDbContext>, IAccountQueryRepository
    {
        public AccountQueryRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}