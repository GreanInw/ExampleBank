using ExampleBank.Web.Data.DbContexts;
using ExampleBank.Web.Data.DbContexts.Base;
using ExampleBank.Web.Repositories.Bases.Queries;
using Microsoft.EntityFrameworkCore;

namespace ExampleBank.Web.Repositories.Bases.Commands
{
    public abstract class CommandRepository<TEntity, TDbContext> : QueryRepository<TEntity, TDbContext>, ICommandRepository<TEntity>
        where TEntity : class
        where TDbContext : IBaseDBContext
    {
        protected CommandRepository(TDbContext dbContext) : base(dbContext)
        { }

        public void Add(TEntity entity) => DbSet.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);

        public void Delete(TEntity entity) => DbSet.Remove(entity);

        public void Edit(TEntity entity)
            => DbSet.Entry(entity).State = EntityState.Modified;
    }
}
