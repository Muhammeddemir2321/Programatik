using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaim;

public class AuthoritySetOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthoritySetOperationClaimCommand, bool>
{
    public async Task<bool> Handle(AuthoritySetOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var authority = await planoraUnitOfWork.Authorities.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claim = await planoraUnitOfWork.AuthorityOperationClaims.GetAsync(l => l.AuthorityId == request.AuthorityId && l.OperationClaimId == request.OperationClaimId, cancellationToken: cancellationToken);
        if (claim is null)
            await planoraUnitOfWork.AuthorityOperationClaims.AddAsync(new AuthorityOperationClaim
            {
                AuthorityId = authority.Id,
                OperationClaimId = request.OperationClaimId
            });
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
