namespace ExampleBank.Web.UOMs
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        int Commit(bool acceptAllChangesOnSuccess);
        Task<int> CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
