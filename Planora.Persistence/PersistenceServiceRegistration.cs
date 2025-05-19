using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
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
        });
        




        services.AddScoped<IClassCourseAssignmentRepository, ClassCourseAssignmentRepository>();
        services.AddScoped<IClassSectionRepository, ClassSectionRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ILectureRepository, LectureRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IBaseUserRepository, BaseUserRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
