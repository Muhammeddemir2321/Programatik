using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;
namespace Planora.Application.Features.IdentityFeature.Commands;

public record IdentitySetAuthorityCommand : IRequest<bool>, ISecuredRequest
{
    public Guid IdentityId { get; set; }
    public Guid AuthorityId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.UpdateAuthorities };
}