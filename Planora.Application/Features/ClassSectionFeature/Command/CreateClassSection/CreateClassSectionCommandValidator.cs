using FluentValidation;

namespace Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;

public class CreateClassSectionCommandValidator:AbstractValidator<CreateClassSectionCommand>
{
    public CreateClassSectionCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    //    RuleFor(x => x.SchoolId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    //    RuleFor(x => x.GradeId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
