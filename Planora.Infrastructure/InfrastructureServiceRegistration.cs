using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Services.Repositories;
using Planora.Infrastructure.Contexts;

namespace Planora.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPlanoraUserContextAccessor, PlanoraUserContextAccessor>();
        return services;
    }
}
