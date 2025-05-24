using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using Planora.Application.Features.OperationClaimFeature.Models;

namespace Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaimByDynamic
{
    public class ListAllOperationClaimByDynamicQuery : IRequest<OperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Query { get; set; }
        public string[] Roles => new string[] { OperationClaimClaimConstants.List };
    }
}
