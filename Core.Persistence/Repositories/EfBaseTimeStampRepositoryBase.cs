using Core.Persistence.Paging;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Threading;

namespace Core.Persistence.Repositories
{
    public class EfBaseTimeStampRepositoryBase<TEntity, TContext> : EfRepositoryBase<TEntity, TContext>, IAsyncBaseTimeStampRepository<TEntity>, IBaseTimeStampRepository<TEntity>
        where TEntity : BaseTimeStampEntity
        where TContext : DbContext
    {
        public EfBaseTimeStampRepositoryBase(TContext context):base(context) { }


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
            var info = ServiceTool.GetUserInfo();
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = info?.FullName ?? "Unknown";
            entity.DeletedUserId = info?.Id ?? Guid.Empty;
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity> RestoreAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.DeletedAt = null;
            entity.DeletedUser = null;
            entity.DeletedUserId = null;
            entity.IsDeleted = false;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
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
            var info = ServiceTool.GetUserInfo();
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = info?.FullName ?? "Unknown";
            entity.DeletedUserId = info?.Id ?? Guid.Empty;
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Restore(TEntity entity)
        {
            entity.DeletedAt = null;
            entity.DeletedUser = null;
            entity.DeletedUserId = null;
            entity.IsDeleted = false;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChangesAsync();
            return entity;
        }
        public override async Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken)
        {
            var info = ServiceTool.GetUserInfo();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = info?.FullName ?? "Unknown";
            entity.CreatedUserId = info?.Id ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public override async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var info = ServiceTool.GetUserInfo();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = info?.FullName ?? "Unknown";
            entity.DeletedUserId = info?.Id ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public override TEntity Add(TEntity entity)
        {
            var info = ServiceTool.GetUserInfo();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = info?.FullName ?? "Unknown";
            entity.CreatedUserId = info?.Id ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChangesAsync();
            return entity;
        }
        public override TEntity Update(TEntity entity)
        {
            var info = ServiceTool.GetUserInfo();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedUser = info?.FullName ?? "Unknown";
            entity.DeletedUserId = info?.Id ?? Guid.Empty;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChangesAsync();
            return entity;
        }
    }
}
