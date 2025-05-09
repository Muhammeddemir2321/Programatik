using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;
using Planora.Persistence.Repositories;

namespace Planora.Persistence;

public static class PersistenceServiceRegistration
{
    public static IConfiguration Configuration;
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        Configuration = configuration;
        var env = configuration.GetValue<string>("GeneralSettings:Environment") ?? "Debug";
        services.AddDbContext<PlanoraDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(env));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
                                                 );
        
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<ILectureRepository, LectureRepository>();
        return services;
    }
}
