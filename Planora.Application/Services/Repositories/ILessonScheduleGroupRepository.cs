using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Planora.Domain.Entities;
using System.Linq.Expressions;

namespace Planora.Application.Services.Repositories;

public interface ILessonScheduleGroupRepository : IAsyncBaseTimeStampRepository<LessonScheduleGroup>, IBaseTimeStampRepository<LessonScheduleGroup>, IDynamicRepository<LessonScheduleGroup>
{
}
