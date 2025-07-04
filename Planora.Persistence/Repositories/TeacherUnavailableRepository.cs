using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class TeacherUnavailableRepository : EfRepositoryBase<TeacherUnavailable, PlanoraDbContext>, ITeacherUnavailableRepository
{
    public TeacherUnavailableRepository(PlanoraDbContext context) : base(context)
    {
    }
}
