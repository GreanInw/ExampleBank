using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Commands;

namespace ExampleBank.Web.Repositories.BankAccounts.Commands
{
    public interface IBankAccountCommandRepository : ICommandRepository<BankAccount> { }
}
