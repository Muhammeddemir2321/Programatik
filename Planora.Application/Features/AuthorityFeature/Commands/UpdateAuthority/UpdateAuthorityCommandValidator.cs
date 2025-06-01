using FluentValidation;

namespace Planora.Application.Features.AuthorityFeature.Commands.UpdateAuthority
{
    public class UpdateAuthorityCommandValidator:AbstractValidator<UpdateAuthorityCommand>
    {
        public UpdateAuthorityCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
