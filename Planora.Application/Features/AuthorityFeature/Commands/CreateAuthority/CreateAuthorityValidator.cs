using FluentValidation;
using Planora.Application.Features.AuthFeature.Commands.CreateToken;

namespace Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;

public class CreateAuthorityValidator:AbstractValidator<CreateAuthorityCommand>
{
    public CreateAuthorityValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        
    }
}
