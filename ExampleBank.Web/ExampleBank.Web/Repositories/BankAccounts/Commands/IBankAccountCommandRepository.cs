using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.BankAccounts.Commands
{
    public interface IBankAccountCommandRepository : ICommandRepository<BankAccount> { }
}
