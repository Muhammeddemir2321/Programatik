using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetAuthority;

public class IdentitySetAuthorityCommandHandler(
    IIdentityAuthorityRepository identityAuthorityRepository,
    IIdentityRepository identityRepository,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetAuthorityCommand, bool>
{
    public async Task<bool> Handle(IdentitySetAuthorityCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var authority = await identityAuthorityRepository.GetAsync(l => l.IdentityId == request.IdentityId && l.AuthorityId == request.AuthorityId, cancellationToken: cancellationToken);
        if (authority is null)
            await identityAuthorityRepository.AddAsync(new IdentityAuthority
            {
                IdentityId = identity.Id,
                AuthorityId = request.AuthorityId
            }, cancellationToken: cancellationToken);
        return true;
    }
}
