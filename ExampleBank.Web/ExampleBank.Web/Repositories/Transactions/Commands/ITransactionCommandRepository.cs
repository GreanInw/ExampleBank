using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.Transactions.Commands
{
    public interface ITransactionCommandRepository : ICommandRepository<Transaction> { }
}
