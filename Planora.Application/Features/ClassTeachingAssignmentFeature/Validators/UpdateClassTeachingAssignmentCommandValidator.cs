using FluentValidation;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Validators;

public class UpdateClassTeachingAssignmentCommandValidator:AbstractValidator<UpdateClassTeachingAssignmentCommand>
{
    public UpdateClassTeachingAssignmentCommandValidator()
    {
        RuleFor(x => x.WeeklyHourCount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("WeeklyHours is required.");
        //RuleFor(x => x.LectureId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("WeeklyHours is required.");
    }
}
