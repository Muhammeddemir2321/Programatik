using AutoMapper;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;

public class ListAllOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
    : IRequestHandler<ListAllOperationClaimQuery, OperationClaimListModel>
{
    public async Task<OperationClaimListModel> Handle(ListAllOperationClaimQuery request, CancellationToken cancellationToken)
    {
        var operationClaims = await operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<OperationClaimListModel>(operationClaims);

        return mappedList;
    }
}
