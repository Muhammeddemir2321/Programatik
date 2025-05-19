using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Planora.Application.Services.Repositories;
using System.Linq.Expressions;

namespace Planora.Persistence.Repositories;

public class BaseUserRepository(UserManager<BaseUser> userManager) : IBaseUserRepository
{
    public async Task<BaseUser?> GetAsync(Expression<Func<BaseUser, bool>> predicate, Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null, Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        return await userManager.Users.FirstOrDefaultAsync(predicate);
    }
    public async Task<IPaginate<BaseUser>> GetListAsync(Expression<Func<BaseUser, bool>>? predicate = null, Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null, Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var queryable = userManager.Users.AsQueryable();
        if (!enableTracking) queryable.AsNoTracking();
        if (include != null) include(queryable);
        if (predicate != null) queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
    public async Task<IPaginate<BaseUser>> GetListByDynamicAsync(Dynamic dynamic, Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<BaseUser> queryable = userManager.Users.AsQueryable();
        if (dynamic != null) queryable = queryable.ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
    public async Task<BaseUser> AddAsync(BaseUser entity, string password)
    {
        var result = await userManager.CreateAsync(entity, password);

        return entity;

    }
    public async Task<BaseUser> UpdateAsync(BaseUser entity)
    {
        var result = await userManager.UpdateAsync(entity);
        if (!result.Succeeded)
            throw new Exception("Güncellenemedi");
        return entity;
    }
    public async Task DeleteAsync(BaseUser entity)
    {
        var result= await userManager.DeleteAsync(entity);
    }

    public async Task<List<BaseUser>> GetAllAsync()
    {
        return await userManager.Users.ToListAsync();
    }


    public Task<IPaginate<BaseUser>> GetListDeletedAsync(Expression<Func<BaseUser, bool>>? predicate = null, Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null, Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<BaseUser>> GetListNotDeletedAsync(Expression<Func<BaseUser, bool>>? predicate = null, Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null, Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<BaseUser> RestoreAsync(BaseUser entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<BaseUser> SoftDeleteAsync(BaseUser entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
