using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Planora.Application.Services.Repositories;

public interface IIdentityOperationClaimRepository : IAsyncRepository<IdentityOperationClaim>, IRepository<IdentityOperationClaim>
{
}
