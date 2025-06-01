using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfBaseTimeStampRepositoryBase<TEntity, TContext> : EfRepositoryBase<TEntity, TContext>, IAsyncBaseTimeStampRepository<TEntity>, IBaseTimeStampRepository<TEntity>
        where TEntity : BaseTimeStampEntity
        where TContext : DbContext
    {
        private readonly IUserContextAccessor _userContextAccessor;
        public EfBaseTimeStampRepositoryBase(TContext context, IUserContextAccessor userContextAccessor) : base(context)
        {
            _userContextAccessor = userContextAccessor;
        }

        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.CreatedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            await Context.AddAsync(entity);
            return entity;
        }
        public override async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.DeletedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }
        public async Task<IPaginate<TEntity>> GetListDeletedAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = Query();
            queryable.Where(x => x.IsDeleted == true);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }
        public async Task<IPaginate<TEntity>> GetListNotDeletedAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = Query();
            queryable.Where(x => x.IsDeleted != true);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }
        public async Task<TEntity> SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.DeletedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(entity);
            return entity;
        }



        public override TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.CreatedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChangesAsync();
            return entity;
        }
        public override TEntity Update(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.DeletedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChangesAsync();
            return entity;
        }
        public IPaginate<TEntity> GetListDeleted(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var queryable = Query();
            queryable.Where(x => x.IsDeleted == true);
            if (!enableTracking) queryable.AsNoTracking();
            if (include != null) include(queryable);
            if (predicate != null) queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size, 0);
            return queryable.ToPaginate(index, size, 0);

        }
        public IPaginate<TEntity> GetListNotDeleted(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 0, bool enableTracking = true)
        {
            var queryable = Query();
            queryable.Where(x => x.IsDeleted != true);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size);
            return queryable.ToPaginate(index, size);
        }
        public TEntity SoftDelete(TEntity entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = _userContextAccessor?.FullName ?? "Unknown";
            entity.DeletedUserId = _userContextAccessor?.UserId ?? Guid.Empty;
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
