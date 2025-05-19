using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Planora.Application.Services.Repositories;
using System.Linq.Expressions;

namespace Planora.Persistence.Repositories;

public class IdentityRepository(UserManager<Identity> userManager) : IIdentityRepository
{
    public async Task<Identity?> GetAsync(Expression<Func<Identity, bool>> predicate, Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null, Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        return await userManager.Users.FirstOrDefaultAsync(predicate);
    }
    public async Task<IPaginate<Identity>> GetListAsync(Expression<Func<Identity, bool>>? predicate = null, Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null, Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var queryable = userManager.Users.AsQueryable();
        if (!enableTracking) queryable.AsNoTracking();
        if (include != null) include(queryable);
        if (predicate != null) queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
    public async Task<IPaginate<Identity>> GetListByDynamicAsync(Dynamic dynamic, Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Identity> queryable = userManager.Users.AsQueryable();
        if (dynamic != null) queryable = queryable.ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
    public async Task<Identity> AddAsync(Identity entity, string password)
    {
        var result = await userManager.CreateAsync(entity, password);

        return entity;

    }
    public async Task<Identity> UpdateAsync(Identity entity)
    {
        var result = await userManager.UpdateAsync(entity);
        if (!result.Succeeded)
            throw new Exception("Güncellenemedi");
        return entity;
    }
    public async Task DeleteAsync(Identity entity)
    {
        var result= await userManager.DeleteAsync(entity);
    }

    public async Task<List<Identity>> GetAllAsync()
    {
        return await userManager.Users.ToListAsync();
    }


    public Task<IPaginate<Identity>> GetListDeletedAsync(Expression<Func<Identity, bool>>? predicate = null, Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null, Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Identity>> GetListNotDeletedAsync(Expression<Func<Identity, bool>>? predicate = null, Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null, Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Identity> RestoreAsync(Identity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Identity> SoftDeleteAsync(Identity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
