using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Planora.Domain.Entities;
using System.Linq.Expressions;

namespace Planora.Application.Services.Repositories;

public interface ILessonScheduleRepository: IAsyncRepository<LessonSchedule>, IRepository<LessonSchedule>, IDynamicRepository<LessonSchedule>
{
    Task<List<LessonSchedule>> GetAllByGroupIdAsync(Guid groupId ,CancellationToken cancellationToken = default);
}
