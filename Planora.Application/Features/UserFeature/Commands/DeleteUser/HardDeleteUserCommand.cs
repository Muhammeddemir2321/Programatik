using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands.HardDeleteIdentity;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Commands.DeleteUser;

public class HardDeleteUserCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public HardDeleteIdentityCommand HardDeleteIdentityCommand { get; set; }

    public string[] Roles => [UserClaimConstants.HardDelete];
}