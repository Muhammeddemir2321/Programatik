using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.OperationClaimFeature.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { OperationClaimClaimConstants.Update };
}
