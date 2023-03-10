using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.Accounts.Commands
{
    public class AccountCommandRepository : CommandRepository<Account, IBankDbContext>, IAccountCommandRepository
    {
        public AccountCommandRepository(IBankDbContext dbContext) : base(dbContext)
        { }
    }
}