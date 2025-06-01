using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class ClassTeachingAssignmentRepository : EfRepositoryBase<ClassTeachingAssignment, PlanoraDbContext>, IClassTeachingAssignmentRepository
{
    public ClassTeachingAssignmentRepository(PlanoraDbContext context) : base(context)
    {
    }
}
