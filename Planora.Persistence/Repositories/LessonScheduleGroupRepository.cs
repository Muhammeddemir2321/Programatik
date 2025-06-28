using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class LessonScheduleGroupRepository : EfBaseTimeStampRepositoryBase<LessonScheduleGroup, PlanoraDbContext>, ILessonScheduleGroupRepository
{
    public LessonScheduleGroupRepository(PlanoraDbContext context, IUserContextAccessor userContextAccessor) : base(context, userContextAccessor)
    {
    }
}
