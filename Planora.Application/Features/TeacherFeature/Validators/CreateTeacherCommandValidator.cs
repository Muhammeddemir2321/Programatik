using FluentValidation;
using Planora.Application.Features.TeacherFeatures.Commands;

namespace Planora.Application.Features.TeacherFeature.Validators;

public class CreateTeacherCommandValidator:AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(x => x.FullName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
