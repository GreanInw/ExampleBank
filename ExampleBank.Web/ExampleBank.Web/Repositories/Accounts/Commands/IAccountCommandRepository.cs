using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.Accounts.Commands
{
    public interface IAccountCommandRepository : ICommandRepository<Account>
    { }
}
