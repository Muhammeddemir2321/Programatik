using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class ClassCourseAssignmentRepository : EfRepositoryBase<ClassCourseAssignment, PlanoraDbContext>, IClassCourseAssignmentRepository
{
    public ClassCourseAssignmentRepository(PlanoraDbContext context) : base(context)
    {
    }
}
