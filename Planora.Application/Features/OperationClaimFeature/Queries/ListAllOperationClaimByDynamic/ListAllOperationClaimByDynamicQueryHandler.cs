using AutoMapper;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaimByDynamic;

public class ListAllOperationClaimByDynamicQueryHandler(
    IOperationClaimRepository operationClaimRepository,
    IMapper mapper)
    : IRequestHandler<ListAllOperationClaimByDynamicQuery, OperationClaimListModel>
{
    public async Task<OperationClaimListModel> Handle(ListAllOperationClaimByDynamicQuery request, CancellationToken cancellationToken)
    {
        var operationClaims = await operationClaimRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<OperationClaimListModel>(operationClaims);
        return mappedList;
    }
}
