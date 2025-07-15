using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class TeacherUnavailableRepository : EfRepositoryBase<TeacherUnavailable, PlanoraDbContext>, ITeacherUnavailableRepository
{
    public TeacherUnavailableRepository(PlanoraDbContext context) : base(context)
    {
    }

    public async Task<List<TeacherUnavailable>> GetListByTeacherIdAsync(Guid teacherId, CancellationToken cancellationToken = default)
    {
        return await Context.TeacherUnavailables
            .Where(t => t.TeacherId == teacherId)
            .ToListAsync(cancellationToken);
    }
}
