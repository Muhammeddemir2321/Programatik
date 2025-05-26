using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.IoC;
public record UserInfo(Guid Id, string FullName, IEnumerable<Claim> Claims);

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }
    public static byte Timeout { get; set; }
    public static bool IsUsedSemaphoreDbContext { get; set; } = false;
}
