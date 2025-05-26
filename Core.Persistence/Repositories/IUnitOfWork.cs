namespace Core.Persistence.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task<TReturn> ExecuteInTransactionAsync<TReturn>(Func<Task<TReturn>> action);
}
