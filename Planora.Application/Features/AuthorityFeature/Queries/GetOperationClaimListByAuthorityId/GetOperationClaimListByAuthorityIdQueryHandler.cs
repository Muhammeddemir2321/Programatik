using Core.Security.Entities;
using MediatR;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Queries.GetOperationClaimListByAuthorityId;

public class GetOperationClaimListByAuthorityIdQueryHandler(
    IOperationClaimRepository operationClaimRepository,
    IAuthorityOperationClaimRepository authorityOperationClaimRepository)
    : IRequestHandler<GetOperationClaimListByAuthorityIdQuery, IList<OperationClaim>>
{
    public async Task<IList<OperationClaim>> Handle(GetOperationClaimListByAuthorityIdQuery request, CancellationToken cancellationToken)
    {
        var authorityOperationClaimList = authorityOperationClaimRepository.GetAll(a => a.AuthorityId == request.Id, enableTracking: false).Select(e => e.OperationClaimId).ToList();
        return await operationClaimRepository.GetAllAsync(e => authorityOperationClaimList.Contains(e.Id), enableTracking: false, cancellationToken: cancellationToken);
    }
}
