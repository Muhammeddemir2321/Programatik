using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetAuthorityList;

public class IdentitySetAuthorityListCommandHandler(
    IIdentityAuthorityRepository identityAuthorityRepository,
    IIdentityRepository identityRepository,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetAuthorityListCommand, bool>
{

    public async Task<bool> Handle(IdentitySetAuthorityListCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var authorityResponse = await identityAuthorityRepository.GetAllAsync(l => l.IdentityId == request.IdentityId, enableTracking: false, cancellationToken: cancellationToken);
        var authorities = authorityResponse.ToList();
        request.Authorities.ForEach(async e =>
        {
            var authority = authorities.Where(c => c.AuthorityId == e)?.FirstOrDefault();
            if (authority is null)
                await identityAuthorityRepository.AddAsync(new IdentityAuthority
                {
                    IdentityId = identity.Id,
                    AuthorityId = e
                }, cancellationToken: cancellationToken);
        });
        if (!request.RemoveExclude) return true;
        authorities.ForEach(async e =>
        {
            var authority = request.Authorities.Where(c => c == e.AuthorityId)?.FirstOrDefault();
            if (authority is null)
                await identityAuthorityRepository.DeleteAsync(e, cancellationToken: cancellationToken);
        });
        return true;
    }
}
