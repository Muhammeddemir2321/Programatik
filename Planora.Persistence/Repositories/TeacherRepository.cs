using Core.Persistence.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class TeacherRepository : EfRepositoryBase<Teacher, PlanoraDbContext>
{
    public TeacherRepository(PlanoraDbContext context) : base(context)
    {
        
    }
}
