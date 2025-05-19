using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Planora.Application.Services.Repositories;

public interface IBaseUserRepository
{
    Task<IPaginate<BaseUser>> GetListNotDeletedAsync(Expression<Func<BaseUser, bool>>? predicate = null,
                                                Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null,
                                                Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null,
                                                int index = 0, int size = 10, bool enableTracking = true,
                                                CancellationToken cancellationToken = default);
    Task<IPaginate<BaseUser>> GetListDeletedAsync(Expression<Func<BaseUser, bool>>? predicate = null,
                                            Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null,
                                            Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null,
                                            int index = 0, int size = 10, bool enableTracking = true,
                                            CancellationToken cancellationToken = default);
    Task<BaseUser> SoftDeleteAsync(BaseUser entity, CancellationToken cancellationToken = default);
    Task<BaseUser> RestoreAsync(BaseUser entity, CancellationToken cancellationToken = default);

    Task<BaseUser?> GetAsync(Expression<Func<BaseUser, bool>>? predicate = null,
                                                Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null,
                                                Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null,
                                                bool enableTracking = true,
                                                CancellationToken cancellationToken = default);
    Task<IPaginate<BaseUser>> GetListAsync(Expression<Func<BaseUser, bool>>? predicate = null,
                                    Func<IQueryable<BaseUser>, IOrderedQueryable<BaseUser>>? orderBy = null,
                                    Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true,
                                    CancellationToken cancellationToken = default);
    Task<IPaginate<BaseUser>> GetListByDynamicAsync(Dynamic dynamic,
        Func<IQueryable<BaseUser>, IIncludableQueryable<BaseUser, object>>?
            include = null, int index = 0, int size = 10,
        bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<List<BaseUser>> GetAllAsync();
    Task<BaseUser> AddAsync(BaseUser entity,string password);
    Task<BaseUser> UpdateAsync(BaseUser entity);
    Task DeleteAsync(BaseUser entity);
}
