using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentityRemoveOperationClaim;

public class IdentitySetOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentityRemoveOperationClaimCommand, bool>
{

    public async Task<bool> Handle(IdentityRemoveOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var claim = await planoraUnitOfWork.IdentityOperationClaims.GetAsync(l => l.IdentityId == request.IdentityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is not null)
        {
            await planoraUnitOfWork.IdentityOperationClaims.DeleteAsync(claim, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
        }
        return true;
    }
}
