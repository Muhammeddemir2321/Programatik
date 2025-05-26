using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetAuthority;

public class IdentitySetAuthorityCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetAuthorityCommand, bool>
{
    public async Task<bool> Handle(IdentitySetAuthorityCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var authority = await planoraUnitOfWork.IdentityAuthorities.GetAsync(l => l.IdentityId == request.IdentityId && l.AuthorityId == request.AuthorityId, cancellationToken: cancellationToken);
        if (authority is null)
        {
            await planoraUnitOfWork.IdentityAuthorities.AddAsync(new IdentityAuthority
            {
                IdentityId = identity.Id,
                AuthorityId = request.AuthorityId
            }, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
        }
            
        return true;
    }
}
