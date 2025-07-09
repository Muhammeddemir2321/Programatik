using FluentValidation;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Command.CreateSchoolScheduleSetting;

public class CreateSchoolScheduleSettingCommandValidator:AbstractValidator<SchoolScheduleSetting>
{
    public CreateSchoolScheduleSettingCommandValidator()
    {
        RuleFor(x => x.FirstLessonStartTime).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.BreakDurationMinutes).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.DailyLessonCount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.LessonDurationMinutes).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
