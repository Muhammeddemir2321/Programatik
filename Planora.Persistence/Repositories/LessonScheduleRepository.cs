using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class LessonScheduleRepository : EfRepositoryBase<LessonSchedule, PlanoraDbContext>, ILessonScheduleRepository
{
    public LessonScheduleRepository(PlanoraDbContext context) : base(context)
    {
    }

    public async Task<List<LessonSchedule>> GetAllByGroupIdAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await Context.LessonSchedules
        .Where(ls => ls.LessonScheduleGroupId == groupId) 
        .ToListAsync(cancellationToken);
    }
}
