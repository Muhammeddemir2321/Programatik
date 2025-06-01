using FluentValidation;
using Planora.Application.Features.GradeFeature.Commands;

namespace Planora.Application.Features.GradeFeature.Validators;

public class CreateGradeCommandValidator:AbstractValidator<CreateGradeCommand>
{
    public CreateGradeCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("WeeklyHours is required.");
    }
}
