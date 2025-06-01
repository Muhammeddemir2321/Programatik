using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class LessonScheduleRepository : EfRepositoryBase<LessonSchedule, PlanoraDbContext>, ILessonScheduleRepository
{
    public LessonScheduleRepository(PlanoraDbContext context) : base(context)
    {
    }
}
