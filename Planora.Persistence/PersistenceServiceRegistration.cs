using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Services.Repositories;
using Planora.Persistance.Repositories;
using Planora.Persistence.Contexts;
using Planora.Persistence.Repositories;
using Uroflow.Persistance.Repositories;

namespace Planora.Persistence;

public static class PersistenceServiceRegistration
{
    public static IConfiguration Configuration;
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        Configuration = configuration;
        var env = configuration.GetValue<string>("GeneralSettings:Environment") ?? "Debug";
        services.AddDbContextFactory<PlanoraDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(env));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });



        services.AddScoped<ILessonScheduleGroupRepository, LessonScheduleGroupRepository>();
        services.AddScoped<ILessonScheduleRepository, LessonScheduleRepository>();
        services.AddScoped<IClassSectionRepository, ClassSectionRepository>();
        services.AddScoped<IClassTeachingAssignmentRepository, ClassTeachingAssignmentRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ILectureRepository, LectureRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<ISchoolScheduleSettingRepository, SchoolScheduleSettingsRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITeacherUnavailableRepository, TeacherUnavailableRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IIdentityAuthorityRepository, IdentityAuthorityRepository>();
        services.AddScoped<IIdentityOperationClaimRepository, IdentityOperationClaimRepository>();
        services.AddScoped<IAuthorityOperationClaimRepository, AuthorityOperationClaimRepository>();
        services.AddScoped<IAuthorityRepository, AuthorityRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IPlanoraUnitOfWork, PlanoraUnitOfWork>();
        return services;
    }
}
