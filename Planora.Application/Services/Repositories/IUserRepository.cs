using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface IUserRepository : IAsyncBaseTimeStampRepository<User>, IBaseTimeStampRepository<User>, IDynamicRepository<User>
{
}
