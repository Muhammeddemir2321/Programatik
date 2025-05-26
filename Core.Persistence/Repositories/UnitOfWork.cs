using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Persistence.Repositories;
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    protected readonly TContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(TContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        if (_transaction != null)
            await _transaction.CommitAsync();
    }
    public async Task RollbackAsync() => await _transaction.RollbackAsync();
    public void Dispose() => _transaction?.Dispose();
    public async Task<TReturn> ExecuteInTransactionAsync<TReturn>(Func<Task<TReturn>> operation)
    {
        await BeginTransactionAsync();
        try
        {
            var result = await operation();
            await CommitAsync();
            return result;
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }
}
