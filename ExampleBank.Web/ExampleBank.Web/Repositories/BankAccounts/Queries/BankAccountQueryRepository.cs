using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Queries;

namespace ExampleBank.Web.Repositories.BankAccounts.Queries
{
    public class BankAccountQueryRepository : QueryRepository<BankAccount, IBankDbContext>
    {
        public BankAccountQueryRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}