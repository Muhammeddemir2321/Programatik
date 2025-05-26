using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Planora.Application.Services.Repositories;

public interface IIdentityRepository
{
    Task<IPaginate<Identity>> GetListNotDeletedAsync(Expression<Func<Identity, bool>>? predicate = null,
                                                Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null,
                                                Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null,
                                                int index = 0, int size = 10, bool enableTracking = true,
                                                CancellationToken cancellationToken = default);
    Task<IPaginate<Identity>> GetListDeletedAsync(Expression<Func<Identity, bool>>? predicate = null,
                                            Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null,
                                            Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null,
                                            int index = 0, int size = 10, bool enableTracking = true,
                                            CancellationToken cancellationToken = default);
    Task<Identity> SoftDeleteAsync(Identity entity, CancellationToken cancellationToken = default);

    Task<Identity?> GetAsync(Expression<Func<Identity, bool>>? predicate = null,
                                                Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null,
                                                Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null,
                                                bool enableTracking = true,
                                                CancellationToken cancellationToken = default);
    Task<IPaginate<Identity>> GetListAsync(Expression<Func<Identity, bool>>? predicate = null,
                                    Func<IQueryable<Identity>, IOrderedQueryable<Identity>>? orderBy = null,
                                    Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true,
                                    CancellationToken cancellationToken = default);
    Task<IPaginate<Identity>> GetListByDynamicAsync(Dynamic dynamic,
        Func<IQueryable<Identity>, IIncludableQueryable<Identity, object>>?
            include = null, int index = 0, int size = 10,
        bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<List<Identity>> GetAllAsync();
    Task<Identity> AddAsync(Identity entity,string password);
    Task<Identity> UpdateAsync(Identity entity);
    Task DeleteAsync(Identity entity);
    Task<bool> CheckPasswordAsync(Identity entity, string password);

}
