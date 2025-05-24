using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.OperationClaimFeature.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>, ISecuredRequest
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public string[] Roles => [OperationClaimClaimConstants.Get];
    }
}
