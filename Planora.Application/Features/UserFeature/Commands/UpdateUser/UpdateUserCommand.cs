using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands;
using Planora.Application.Features.UserFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.UserFeature.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UpdatedUserDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public bool IsVerify { get; set; }
    public UpdateIdentityCommand UpdateIdentityCommand { get; set; }
    [JsonIgnore]
    public string[] Roles => [UserClaimConstants.Update];
}
