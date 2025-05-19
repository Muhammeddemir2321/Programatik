using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Commad;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Command.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>, ISecuredRequest
{
    public CreateBaseUserCommand createBaseUserCommand {  get; set; }
    public Guid SchoolId { get; set; }
    public string[] Roles => [UserClaimConstants.Create];
}
