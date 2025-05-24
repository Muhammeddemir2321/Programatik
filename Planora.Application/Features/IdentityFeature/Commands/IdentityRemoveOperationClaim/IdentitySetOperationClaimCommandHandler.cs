using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentityRemoveOperationClaim;

public class IdentitySetOperationClaimCommandHandler(
    IIdentityOperationClaimRepository identityOperationClaimRepository,
    IIdentityRepository identityRepository,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentityRemoveOperationClaimCommand, bool>
{

    public async Task<bool> Handle(IdentityRemoveOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var claim = await identityOperationClaimRepository.GetAsync(l => l.IdentityId == request.IdentityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is not null)
            await identityOperationClaimRepository.DeleteAsync(claim, cancellationToken: cancellationToken);
        return true;
    }
}
