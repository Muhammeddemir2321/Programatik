using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Uroflow.Persistance.Repositories;

public class IdentityOperationClaimRepository : EfRepositoryBase<IdentityOperationClaim, PlanoraDbContext>, IIdentityOperationClaimRepository
{
    public IdentityOperationClaimRepository(PlanoraDbContext context) : base(context) { }
}
