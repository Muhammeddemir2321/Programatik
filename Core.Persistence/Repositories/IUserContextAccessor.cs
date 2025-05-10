using System.Security.Claims;

namespace Core.Persistence.Repositories;

public interface IUserContextAccessor
{
    Guid? UserId { get; }
    string? FullName { get; }
    IEnumerable<Claim>? Claims { get; }
}
