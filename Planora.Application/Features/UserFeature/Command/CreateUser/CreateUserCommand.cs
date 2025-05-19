using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commad;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Command.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>, ISecuredRequest
{
    public CreateIdentityCommand createIdentityCommand {  get; set; }
    public Guid SchoolId { get; set; }
    public string[] Roles => [UserClaimConstants.Create];
}
