using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class CourseRepository : EfRepositoryBase<Course, PlanoraDbContext>, ICourseRepository
{
    public CourseRepository(PlanoraDbContext context) : base(context)
    {
        
    }
}
