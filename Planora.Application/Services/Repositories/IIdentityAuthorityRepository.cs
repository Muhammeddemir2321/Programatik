using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Planora.Application.Services.Repositories;

public interface IIdentityAuthorityRepository : IAsyncRepository<IdentityAuthority>, IRepository<IdentityAuthority>
{
}
