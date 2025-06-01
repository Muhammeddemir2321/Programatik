using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public abstract class EfRepositoryBase<TEntity, TContext> :
    IAsyncRepository<TEntity>,
    IRepository<TEntity>,
    IDynamicRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    private readonly SemaphoreSlim Semaphore = new(1, 1);
    protected TContext Context { get; private set; }
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }
    protected async Task<TReturn> InitialSemaphoreAsync<TReturn>(Func<Task<TReturn>> func, CancellationToken cancellation = default)
    {
        await Semaphore.WaitAsync(cancellation);
        try
        {
            return await func();
        }
        finally
        {
            Semaphore.Release();
        }
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            if (include == null)
                return await Query().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            var queryable = Query();
            queryable = include(queryable);
            return await queryable.Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }, cancellationToken);
    }
    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            var queryable = Query();
            if (!enableTracking) queryable.AsNoTracking();
            if (include != null) include(queryable);
            if (predicate != null) queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToListAsync(cancellationToken);
            return await queryable.ToListAsync(cancellationToken);
        }, cancellationToken);
        
    }
    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async ()=>
        {
            var queryable = Query();
            if (!enableTracking) queryable.AsNoTracking();
            if (include != null) include(queryable);
            if (predicate != null) queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }, cancellationToken);
        
    }
    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            IQueryable<TEntity> queryable = Query();
            if (dynamic != null) queryable = queryable.ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }, cancellationToken);
    }
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            await Context.AddAsync(entity);
            return entity;
        },cancellationToken);
    }
    public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return InitialSemaphoreAsync(async () =>
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }, cancellationToken);
    }
    public virtual async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await Task.FromResult(entity);
        }, cancellationToken);
    }
    


    protected TReturn InitialSemaphore<TReturn>(Func<TReturn> func)
    {
        Semaphore.Wait();
        try
        {
            return func();
        }
        finally
        {
            Semaphore.Release();
        }
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        return InitialSemaphore(() =>
        {
            if (include == null)
                return  Query().Where(predicate).AsNoTracking().FirstOrDefault();
            var queryable = Query();
            queryable = include(queryable);
            return  queryable.Where(predicate).AsNoTracking().FirstOrDefault();
        });
    }
    public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        return InitialSemaphore(() =>
        {
            var queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToList();
            return queryable.ToList();
        });
    }
    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        return InitialSemaphore(() =>
        {
            var queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size);
            return queryable.ToPaginate(index, size);
        });
    }
    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        return InitialSemaphore(() =>
        {
            var queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return queryable.ToPaginate(index, size);
        });
    }
    public virtual TEntity Add(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Add(entity);
            return entity;
        });
    }
    public virtual TEntity Update(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        });
    }
    public virtual TEntity Delete(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return entity;
        });
    }

}