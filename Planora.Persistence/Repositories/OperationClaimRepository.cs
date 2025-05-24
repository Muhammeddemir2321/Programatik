using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Uroflow.Persistance.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, PlanoraDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(PlanoraDbContext context) : base(context)
    {
    }
}