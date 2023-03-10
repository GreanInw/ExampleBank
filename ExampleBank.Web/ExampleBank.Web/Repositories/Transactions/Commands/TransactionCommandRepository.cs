using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using ExampleBank.Web.Repositories.Bases.Commands;

namespace ExampleBank.Web.Repositories.Transactions.Commands
{
    public class TransactionCommandRepository : CommandRepository<Transaction, IBankDbContext>, ITransactionCommandRepository
    {
        public TransactionCommandRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}