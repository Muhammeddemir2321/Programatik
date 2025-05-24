using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaimList;

public class AuthoritySetOperationClaimListCommandHandler(
    IAuthorityOperationClaimRepository authorityOperationClaimRepository,
    IAuthorityRepository authorityRepository,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<AuthoritySetOperationClaimListCommand, bool>
{

    public async Task<bool> Handle(AuthoritySetOperationClaimListCommand request, CancellationToken cancellationToken)
    {
        var authority = await authorityRepository.GetAsync(u => u.Id == request.AuthorityId, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        var claimResponse = await authorityOperationClaimRepository.GetAllAsync(l => l.AuthorityId == request.AuthorityId, enableTracking: false, cancellationToken: cancellationToken);
        var claims = claimResponse.ToList();
        request.OperationClaims.ForEach(e =>
        {
            var claim = claims.Where(c => c.OperationClaimId == e)?.FirstOrDefault();
            if (claim is null)
                authorityOperationClaimRepository.Add(new()
                {
                    AuthorityId = authority.Id,
                    OperationClaimId = e
                });
        });
        if (!request.RemoveExclude) return true;
        claims.ForEach(e =>
        {
            var claim = request.OperationClaims.Where(c => c == e.OperationClaimId)?.FirstOrDefault();
            if (claim is null)
                authorityOperationClaimRepository.Delete(e);
        });
        return true;
    }
}
