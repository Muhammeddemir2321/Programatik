using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string Group { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { OperationClaimClaimConstants.Create };
    
}
