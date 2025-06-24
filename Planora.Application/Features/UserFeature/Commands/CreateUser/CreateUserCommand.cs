using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;
using Planora.Application.Features.UserFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.UserFeature.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>, ISecuredRequest
{
    public CreateIdentityCommand createIdentityCommand {  get; set; }
    public Guid SchoolId { get; set; }
    [JsonIgnore]
    public string[] Roles => [UserClaimConstants.Create];
}
