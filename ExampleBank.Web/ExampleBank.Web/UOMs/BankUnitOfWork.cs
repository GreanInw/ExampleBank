using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.UOMs.Bases;

namespace ExampleBank.Web.UOMs
{
    public class BankUnitOfWork : UnitOfWork<IBankDbContext>, IBankUnitOfWork
    {
        public BankUnitOfWork(IBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}