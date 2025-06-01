using FluentValidation;
using Planora.Application.Features.TeacherFeatures.Commands;

namespace Planora.Application.Features.TeacherFeature.Validators;

public class UpdateTeacherCommandValidator:AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(x => x.FullName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
