using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthorityRemoveOperationClaim;

public class AuthoritySetOperationClaimCommandHandler(
    IAuthorityOperationClaimRepository authorityOperationClaimRepository,
    IAuthorityRepository authorityRepository,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthorityRemoveOperationClaimCommand, bool>
{
    public async Task<bool> Handle(AuthorityRemoveOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var authority = await authorityRepository.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claim = await authorityOperationClaimRepository.GetAsync(l => l.AuthorityId == request.AuthorityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is not null)
            await authorityOperationClaimRepository.DeleteAsync(claim, cancellationToken: cancellationToken);
        return true;
    }
}
