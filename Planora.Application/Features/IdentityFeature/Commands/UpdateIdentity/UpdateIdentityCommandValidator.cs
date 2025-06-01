using FluentValidation;

namespace Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;

public class UpdateIdentityCommandValidator:AbstractValidator<UpdateIdentityCommand>
{
    public UpdateIdentityCommandValidator()
    {
        RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Username).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("WeeklyHours is required.").EmailAddress().WithMessage("{PropertyName} format is wrong");
        
    }
}
