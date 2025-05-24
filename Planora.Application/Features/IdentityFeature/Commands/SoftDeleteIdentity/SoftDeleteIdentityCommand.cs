using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commands.SoftDeleteIdentity;

public class SoftDeleteIdentityCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.SoftDelete };
}
