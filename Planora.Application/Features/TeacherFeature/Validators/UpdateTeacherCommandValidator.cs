using FluentValidation;
using Planora.Application.Features.TeacherFeatures.Commands;

namespace Planora.Application.Features.TeacherFeature.Validators;

public class UpdateTeacherCommandValidator:AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
