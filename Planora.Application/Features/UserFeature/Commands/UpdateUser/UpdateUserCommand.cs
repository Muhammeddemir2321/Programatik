using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands;
using Planora.Application.Features.UserFeature.Constants;

namespace Planora.Application.Features.UserFeature.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UpdatedUserDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public bool IsVerify { get; set; }
    public UpdateIdentityCommand UpdateIdentityCommand { get; set; }
    public string[] Roles => [UserClaimConstants.Update];
}
