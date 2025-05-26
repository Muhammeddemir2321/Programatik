using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentityRemoveAuthority;

public class IdentitySetAuthorityCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentityRemoveAuthorityCommand, bool>
{
    public async Task<bool> Handle(IdentityRemoveAuthorityCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var authority = await planoraUnitOfWork.IdentityAuthorities.GetAsync(l => l.IdentityId == request.IdentityId && l.AuthorityId == request.AuthorityId, cancellationToken: cancellationToken);
        if (authority is not null)
        {
            await planoraUnitOfWork.IdentityAuthorities.DeleteAsync(authority, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
        }
        return true;
    }
}
