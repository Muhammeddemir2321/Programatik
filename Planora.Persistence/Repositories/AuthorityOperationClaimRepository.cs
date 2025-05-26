using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Planora.Persistance.Repositories;

public class AuthorityOperationClaimRepository : EfRepositoryBase<AuthorityOperationClaim, PlanoraDbContext>, IAuthorityOperationClaimRepository
{
    public AuthorityOperationClaimRepository(PlanoraDbContext context) : base(context)
    {
    }
}