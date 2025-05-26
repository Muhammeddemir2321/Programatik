using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetOperationClaim;

public class IdentitySetOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetOperationClaimCommand, bool>
{

    public async Task<bool> Handle(IdentitySetOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var claim = await planoraUnitOfWork.IdentityOperationClaims.GetAsync(l => l.IdentityId == request.IdentityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is null)
        {
            await planoraUnitOfWork.IdentityOperationClaims.AddAsync(new IdentityOperationClaim
            {
                IdentityId = identity.Id,
                OperationClaimId = request.OperationClaimId
            }, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
        }
            
        return true;
    }
}
