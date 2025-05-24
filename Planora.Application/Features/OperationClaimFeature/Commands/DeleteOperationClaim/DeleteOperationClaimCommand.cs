using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.OperationClaimFeature.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { OperationClaimClaimConstants.Delete };
    
}
