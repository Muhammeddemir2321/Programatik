using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.IoC;
public record UserInfo(Guid Id, string FullName, IEnumerable<Claim> Claims);

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }
    private static object Application { get; set; }
    private static object DbContextOptions { get; set; }
    public static SemaphoreSlim DbContextSemaphore { get; private set; } = new SemaphoreSlim(1);
    public static byte Timeout { get; set; }
    public static bool IsUsedSemaphoreDbContext { get; set; } = false;

    private static void ThreadSemaphore()
    {
        while (true)
        {
            try
            {
                Thread.Sleep(1000);
                if (Timeout > 0)
                {
                    Timeout--;
                    continue;
                }

                DbContextSemaphore.Release();
            }
            catch (Exception)
            {
            }
        }

    }
    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        new Thread(() =>
        {
            ThreadSemaphore();
        }).Start();
        return services;
    }
    public static T GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }
    public static IHttpContextAccessor GetHttpContextAccessor()
    {
        return GetService<IHttpContextAccessor>();
    }
    public static UserInfo? GetUserInfo()
    {
        var context = GetHttpContextAccessor();
        if (context.HttpContext == null) return null;
        var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return null;
        var userName = context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        var roles = context.HttpContext.User.FindAll(ClaimTypes.Role);
        return new UserInfo(Guid.Parse(userId), userName ?? "Unknown", roles);

    }

    public static void SetAppplication<T>(T application)
    {
        Application = application;
    }
    public static T GetAppplication<T>()
    {
        return (T)Application;
    }
    public static void SetDbContextOptions<T>(T dbContextOptions)
    {
        DbContextOptions = dbContextOptions;
    }
    public static T GetDbContextOptions<T>()
    {
        return (T)DbContextOptions;
    }



}
