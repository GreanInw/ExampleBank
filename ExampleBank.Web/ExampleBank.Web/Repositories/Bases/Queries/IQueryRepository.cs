namespace HR.Common.DALs.Repositories.Queries
{
    public interface IQueryRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        TEntity GetById(params object[] keyValues);
        ValueTask<TEntity> GetByIdAsync(params object[] keyValues);
        Task ReloadAsync(TEntity entity);
    }
}