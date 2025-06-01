using FluentValidation;
using Planora.Application.Features.LectureFeature.Commands;

namespace Planora.Application.Features.LectureFeature.Validators;

public class CreateLectureCommandValidator:AbstractValidator<CreateLectureCommand>
{
    public CreateLectureCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
