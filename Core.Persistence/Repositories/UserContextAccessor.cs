using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Persistence.Repositories;

public class UserContextAccessor : IUserContextAccessor
{
    protected readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId => Guid.TryParse(
        _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
        out var id) ? id : null;

    public string? FullName =>
        _httpContextAccessor.HttpContext?.User.FindFirst("fullName")?.Value;

    public IEnumerable<Claim>? Claims =>
        _httpContextAccessor.HttpContext?.User?.Claims;
}

