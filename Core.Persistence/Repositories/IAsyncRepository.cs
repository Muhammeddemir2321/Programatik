﻿using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;
public interface IAsyncRepository<T> :IQuery<T> where T :Entity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? predicate=null,
                                Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy=null,
                                Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null,
                                bool enableTracking=true,
                                CancellationToken cancellationToken = default);
    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true,
                                    CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
     
}
