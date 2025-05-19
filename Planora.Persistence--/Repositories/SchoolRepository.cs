using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class SchoolRepository : EfRepositoryBase<School, PlanoraDbContext>, ISchoolRepository
{
    public SchoolRepository(PlanoraDbContext context):base(context)
    {
        
    }
}
