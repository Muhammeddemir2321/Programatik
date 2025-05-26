using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Uroflow.Persistance.Repositories;

public class IdentityAuthorityRepository : EfRepositoryBase<IdentityAuthority, PlanoraDbContext>, IIdentityAuthorityRepository
{
    public IdentityAuthorityRepository(PlanoraDbContext context) : base(context)
    {
    }
}
