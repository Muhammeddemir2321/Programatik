using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaim;

public record AuthoritySetOperationClaimCommand : IRequest<bool>, ISecuredRequest
{
    public Guid AuthorityId { get; set; }
    public Guid OperationClaimId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.UpdateClaims };
}