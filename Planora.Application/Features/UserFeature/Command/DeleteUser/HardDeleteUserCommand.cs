using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Commad;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Command.DeleteUser;

public class HardDeleteUserCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public HardDeleteBaseUserCommand HardDeleteBaseUserCommand { get; set; }

    public string[] Roles => [UserClaimConstants.HardDelete];
}
