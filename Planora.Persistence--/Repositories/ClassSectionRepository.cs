using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class ClassSectionRepository : EfRepositoryBase<ClassSection, PlanoraDbContext>, IClassSectionRepository
{
    public ClassSectionRepository(PlanoraDbContext context) : base(context)
    {
    }
}
