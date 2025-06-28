using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Planora.Application.Features.AuthFeature.Rules;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Features.GradeFeature.Rules;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Features.SchoolScheduleSettingFeature.Rules;
using Planora.Application.Features.TeacherFeature.Rules;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.AuthService;
using System.Reflection;

namespace Planora.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<LectureBusinessRules>();
            services.AddScoped<SchoolBusinessRules>();
            services.AddScoped<SchoolScheduleSettingBusinessRules>();
            services.AddScoped<ClassSectionBusinessRules>();
            services.AddScoped<GradeBusinessRules>();
            services.AddScoped<TeacherBusinessRules>();
            services.AddScoped<ClassTeachingAssignmentBusinessRules>();
            services.AddScoped<LessonScheduleBusinessRules>();
            services.AddScoped<LessonScheduleGroupBusinessRules>();
            services.AddScoped<IdentityBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<AuthorityBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ILessonScheduler, LessonScheduler>();
            return services;
        }
    }
}
