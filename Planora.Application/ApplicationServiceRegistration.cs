using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Features.GradeFeatures.Rules;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Features.SchoolFeature.Rules;
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
            return services;
        }
    }
}
