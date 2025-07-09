using FluentValidation;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Validators;

public class CreateClassTeachingAssignmentCommandValidator:AbstractValidator<CreateClassTeachingAssignmentCommand>
{
    public CreateClassTeachingAssignmentCommandValidator()
    {
        RuleFor(x => x.WeeklyHourCount).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        //RuleFor(x => x.LectureId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
