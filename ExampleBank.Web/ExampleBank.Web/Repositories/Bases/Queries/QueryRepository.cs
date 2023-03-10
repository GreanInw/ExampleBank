using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.DbContexts.Base;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Repositories.Bases.Queries
{
    public abstract class QueryRepository<TEntity, TDbContext> : IQueryRepository<TEntity>
        where TEntity : class
        where TDbContext : IBaseDBContext
    {
        public QueryRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected TDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> All => DbSet.AsQueryable();

        public void Dispose() => DbContext.Dispose();

        public async Task ReloadAsync(TEntity entity)
            => await DbContext.Entry(entity).ReloadAsync();

        public TEntity GetById(params object[] keyValues) => DbSet.Find(keyValues);

        public async ValueTask<TEntity> GetByIdAsync(params object[] keyValues)
            => await DbSet.FindAsync(keyValues);
    }
}
