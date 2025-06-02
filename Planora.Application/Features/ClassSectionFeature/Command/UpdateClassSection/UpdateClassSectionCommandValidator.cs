using FluentValidation;

namespace Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;

public class UpdateClassSectionCommandValidator:AbstractValidator<UpdateClassSectionCommand>
{
    public UpdateClassSectionCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.SchoolId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.GradeId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
