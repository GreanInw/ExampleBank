using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Commands;

namespace ExampleBank.Web.Repositories.Transactions.Commands
{
    public interface ITransactionCommandRepository : ICommandRepository<Transaction> { }
}
