using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Commands;

namespace ExampleBank.Web.Repositories.Accounts.Commands
{
    public interface IAccountCommandRepository : ICommandRepository<Account>
    { }
}
