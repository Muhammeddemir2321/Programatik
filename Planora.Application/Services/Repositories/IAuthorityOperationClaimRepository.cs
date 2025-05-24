using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Planora.Application.Services.Repositories;
public interface IAuthorityOperationClaimRepository : IAsyncRepository<AuthorityOperationClaim>, IRepository<AuthorityOperationClaim>
{
}