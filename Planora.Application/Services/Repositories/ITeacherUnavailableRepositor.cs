using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Planora.Domain.Entities;
using System.Linq.Expressions;

namespace Planora.Application.Services.Repositories;

public interface ITeacherUnavailableRepository : IAsyncRepository<TeacherUnavailable>, IRepository<TeacherUnavailable>, IDynamicRepository<TeacherUnavailable>
{
    Task<List<TeacherUnavailable>> GetListByTeacherIdAsync(Guid teacherId,
                                    CancellationToken cancellationToken = default);
}
