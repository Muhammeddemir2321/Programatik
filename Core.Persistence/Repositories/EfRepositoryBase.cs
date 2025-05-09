using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Threading;

namespace Core.Persistence.Repositories;

public abstract class EfRepositoryBase<TEntity, TContext> :
    IAsyncRepository<TEntity>,
    IRepository<TEntity>,
    IDynamicRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected TContext Context { get; private set; }
    protected SemaphoreSlim Semaphore => ServiceTool.DbContextSemaphore;
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
        if (ServiceTool.IsUsedSemaphoreDbContext == false)
            await Semaphore.WaitAsync(cancellation);
        var result = await func();
        if (ServiceTool.IsUsedSemaphoreDbContext == false)
            Semaphore.Release();
        return result;
    }
    protected TReturn InitialSemaphore<TReturn>(Func<TReturn> func)
    {
        if (ServiceTool.IsUsedSemaphoreDbContext == false)
            Semaphore.Wait();
        var result = func();
        if (ServiceTool.IsUsedSemaphoreDbContext == false)
            Semaphore.Release();
        return result;
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
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        },cancellationToken);
    }
    public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return InitialSemaphoreAsync(async () =>
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }, cancellationToken);
    }
    public virtual async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await InitialSemaphoreAsync(async () =>
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }, cancellationToken);
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
    public virtual TEntity Add(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        });
    }
    public virtual TEntity Update(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        });
    }
    public virtual TEntity Delete(TEntity entity)
    {
        return InitialSemaphore(() =>
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        });
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
}