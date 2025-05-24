using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaimList;

public record AuthoritySetOperationClaimListCommand : IRequest<bool>, ISecuredRequest
{
    public Guid AuthorityId { get; set; }
    public List<Guid> OperationClaims { get; set; }
    public bool RemoveExclude { get; set; } = true;
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.UpdateClaims };
}