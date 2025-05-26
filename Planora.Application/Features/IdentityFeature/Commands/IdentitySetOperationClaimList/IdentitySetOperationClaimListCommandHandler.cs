using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.IdentitySetOperationClaimList;

public class IdentitySetOperationClaimListCommandHandler(

    IPlanoraUnitOfWork planoraUnitOfWork,
    IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<IdentitySetOperationClaimListCommand, bool>
{

    public async Task<bool> Handle(IdentitySetOperationClaimListCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.IdentityId, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        var claimResponse = await planoraUnitOfWork.IdentityOperationClaims.GetAllAsync(l => l.IdentityId == request.IdentityId, enableTracking: false, cancellationToken: cancellationToken);
        var claims = claimResponse.ToList();
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            request.OperationClaims.ForEach(async e =>
            {
                var claim = claims.Where(c => c.OperationClaimId == e)?.FirstOrDefault();
                if (claim is null)
                    await planoraUnitOfWork.IdentityOperationClaims.AddAsync(new IdentityOperationClaim
                    {
                        IdentityId = identity.Id,
                        OperationClaimId = e
                    }, cancellationToken: cancellationToken);
            });
            if (!request.RemoveExclude) return true;
            claims.ForEach(async e =>
            {
                var claim = request.OperationClaims.Where(c => c == e.OperationClaimId)?.FirstOrDefault();
                if (claim is null)
                    await planoraUnitOfWork.IdentityOperationClaims.DeleteAsync(e, cancellationToken: cancellationToken);
            });
            return true;
        });
    }
}
