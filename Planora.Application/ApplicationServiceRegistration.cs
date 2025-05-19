using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Features.CourseFeature.Rules;
using Planora.Application.Features.GradeFeature.Rules;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Features.TeacherFeature.Rules;
using Planora.Application.Features.UserFeature.Rules;
using System.Reflection;

namespace Planora.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<LectureBusinessRules>();
            services.AddScoped<SchoolBusinessRules>();
            services.AddScoped<GradeBusinessRules>();
            services.AddScoped<TeacherBusinessRules>();
            services.AddScoped<CourseBusinessRules>();
            services.AddScoped<IdentityBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            return services;
        }
    }
}
