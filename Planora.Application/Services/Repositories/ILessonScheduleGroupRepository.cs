using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ILessonScheduleGroupRepository : IAsyncBaseTimeStampRepository<LessonScheduleGroup>, IBaseTimeStampRepository<LessonScheduleGroup>, IDynamicRepository<LessonScheduleGroup>
{
}
