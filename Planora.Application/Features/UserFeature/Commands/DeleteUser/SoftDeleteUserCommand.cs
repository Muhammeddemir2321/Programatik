using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands.SoftDeleteIdentity;
using Planora.Application.Features.UserFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.UserFeature.Commands.DeleteUser;

public class SoftDeleteUserCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public SoftDeleteIdentityCommand SoftDeleteIdentityCommand { get; set; }
    [JsonIgnore]
    public string[] Roles => [UserClaimConstants.SoftDelete];
}
