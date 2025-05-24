using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaim;

public class AuthoritySetOperationClaimCommandHandler(
    IAuthorityOperationClaimRepository authorityOperationClaimRepository,
    IAuthorityRepository authorityRepository,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthoritySetOperationClaimCommand, bool>
{
    public async Task<bool> Handle(AuthoritySetOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var authority = await authorityRepository.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claim = await authorityOperationClaimRepository.GetAsync(l => l.AuthorityId == request.AuthorityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is null)
            authorityOperationClaimRepository.Add(new AuthorityOperationClaim
            {
                AuthorityId = authority.Id,
                OperationClaimId = request.OperationClaimId
            });
        return true;
    }
}
