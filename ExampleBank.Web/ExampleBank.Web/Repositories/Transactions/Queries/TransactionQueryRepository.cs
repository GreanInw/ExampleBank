using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.Tables;
using HR.Common.DALs.Repositories.Queries;

namespace ExampleBank.Web.Repositories.Transactions.Queries
{
    public class TransactionQueryRepository : QueryRepository<Transaction, IBankDbContext>, ITransactionQueryRepository
    {
        public TransactionQueryRepository(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}