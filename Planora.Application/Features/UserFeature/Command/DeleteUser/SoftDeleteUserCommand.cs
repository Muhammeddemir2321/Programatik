using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Commad;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Command.DeleteUser;

public class SoftDeleteUserCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public SoftDeleteBaseUserCommand SoftDeleteBaseUserCommand { get; set; }

    public string[] Roles => [UserClaimConstants.SoftDelete];
}
