namespace Planora.Application.Features.UserFeature.Commands.UpdateUser;

public class UpdatedUserDto
{
    public Guid SchoolId { get; set; }
    public Guid IdentityId { get; set; }
    public bool IsVerify { get; set; }
}
