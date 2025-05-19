namespace Planora.Application.Features.UserFeature.Command.UpdateUser;

public class UpdatedUserDto
{
    public Guid SchoolId { get; set; }
    public Guid BaseUserId { get; set; }
    public bool IsVerify { get; set; }
}
