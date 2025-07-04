using FluentValidation;
using Planora.Application.Features.SchoolFeature.Commands;

namespace Planora.Application.Features.SchoolFeature.Validators;

public class CreateSchoolCommandValidator:AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        //RuleFor(x => x.Address).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
    }
}
