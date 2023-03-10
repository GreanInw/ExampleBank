using HR.Common.DALs.Repositories.Queries;

namespace HR.Common.DALs.Repositories.Commands
{
    public interface ICommandRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
    }
}
