using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class GradeRepository : EfRepositoryBase<Grade, PlanoraDbContext>, IGradeRepository
{
    public GradeRepository(PlanoraDbContext context) : base(context)
    {
    }
}
