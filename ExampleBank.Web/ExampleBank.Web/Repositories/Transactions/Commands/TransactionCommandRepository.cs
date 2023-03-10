using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Commands;

namespace ExampleBank.Web.Repositories.Transactions.Commands
{
    public class TransactionCommandRepository : CommandRepository<Transaction, IBankDbContext>, ITransactionCommandRepository
    {
        public TransactionCommandRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}