using FluentValidation;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Command.UpdateSchoolScheduleSetting;

public class UpdateSchoolScheduleSettingCommandValidator:AbstractValidator<SchoolScheduleSetting>
{
    public UpdateSchoolScheduleSettingCommandValidator()
    {
        RuleFor(x => x.FirstLessonStartTime).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.BreakDurationMinutes).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.DailyLessonCount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.LessonDurationMinutes).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
