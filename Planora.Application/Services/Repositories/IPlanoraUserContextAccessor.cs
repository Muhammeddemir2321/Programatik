using Core.Persistence.Repositories;

namespace Planora.Application.Services.Repositories;

public interface IPlanoraUserContextAccessor : IUserContextAccessor
{
    Guid? SchoolId { get; }
}
