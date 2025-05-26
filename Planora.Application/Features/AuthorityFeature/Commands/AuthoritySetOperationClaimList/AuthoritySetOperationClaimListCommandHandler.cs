using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaimList;

public class AuthoritySetOperationClaimListCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthoritySetOperationClaimListCommand, bool>
{

    public async Task<bool> Handle(AuthoritySetOperationClaimListCommand request, CancellationToken cancellationToken)
    {
        var authority = await planoraUnitOfWork.Authorities.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claimResponse = await planoraUnitOfWork.AuthorityOperationClaims.GetAllAsync(l => l.AuthorityId == request.AuthorityId, enableTracking: false, cancellationToken: cancellationToken);
        var claims = claimResponse.ToList();
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            foreach (var e in request.OperationClaims)
            {
                var claim = claims.FirstOrDefault(c => c.OperationClaimId == e);
                if (claim is null)
                {
                    await planoraUnitOfWork.AuthorityOperationClaims.AddAsync(new()
                    {
                        AuthorityId = authority.Id,
                        OperationClaimId = e
                    });
                }
            }

            if (request.RemoveExclude)
            {
                foreach (var e in claims)
                {
                    var claim = request.OperationClaims.FirstOrDefault(c => c == e.OperationClaimId);
                    if (!request.OperationClaims.Contains(e.OperationClaimId))
                    {
                        await planoraUnitOfWork.AuthorityOperationClaims.DeleteAsync(e);
                    }
                }
            }

            return true;
        });
    }
}
