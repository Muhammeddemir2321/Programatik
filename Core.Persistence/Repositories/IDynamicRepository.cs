using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IDynamicRepository<T> where T : Entity
{
    Task<IPaginate<T>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>?
            include = null, int index = 0, int size = 10,
        bool enableTracking = true, CancellationToken cancellationToken = default);
    
    IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true);
}