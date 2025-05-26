using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthorityRemoveOperationClaim;

public class AuthoritySetOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthorityRemoveOperationClaimCommand, bool>
{
    public async Task<bool> Handle(AuthorityRemoveOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var authority = await planoraUnitOfWork.Authorities.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claim = await planoraUnitOfWork.AuthorityOperationClaims.GetAsync(l => l.AuthorityId == request.AuthorityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is not null)
            await planoraUnitOfWork.AuthorityOperationClaims.DeleteAsync(claim, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
