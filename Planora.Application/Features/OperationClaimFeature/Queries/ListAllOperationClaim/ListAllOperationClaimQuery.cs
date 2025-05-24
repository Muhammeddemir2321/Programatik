using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using Planora.Application.Features.OperationClaimFeature.Models;

namespace Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;

public class ListAllOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }


    public string[] Roles => new string[] { OperationClaimClaimConstants.List };

}
