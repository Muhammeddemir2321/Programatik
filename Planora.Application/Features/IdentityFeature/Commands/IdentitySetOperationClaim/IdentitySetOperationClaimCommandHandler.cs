using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetOperationClaim;

public class IdentitySetOperationClaimCommandHandler(
    IIdentityOperationClaimRepository identityOperationClaimRepository,
    IIdentityRepository identityRepository,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetOperationClaimCommand, bool>
{

    public async Task<bool> Handle(IdentitySetOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var claim = await identityOperationClaimRepository.GetAsync(l => l.IdentityId == request.IdentityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is null)
            await identityOperationClaimRepository.AddAsync(new IdentityOperationClaim
            {
                IdentityId = identity.Id,
                OperationClaimId = request.OperationClaimId
            }, cancellationToken: cancellationToken);
        return true;
    }
}
