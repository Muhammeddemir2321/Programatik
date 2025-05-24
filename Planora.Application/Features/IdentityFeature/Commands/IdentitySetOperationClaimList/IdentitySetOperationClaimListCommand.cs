using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commands;

public record IdentitySetOperationClaimListCommand : IRequest<bool>, ISecuredRequest
{
    public Guid IdentityId { get; set; }
    public List<Guid> OperationClaims { get; set; }
    public bool RemoveExclude { get; set; } = true;
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.UpdateOperationClaim };
}