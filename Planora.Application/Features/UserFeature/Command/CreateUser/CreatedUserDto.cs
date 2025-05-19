namespace Planora.Application.Features.UserFeature.Command.CreateUser;

public class CreatedUserDto
{
    public Guid SchoolId { get; set; }
    public Guid IdentityId { get; set; }
    public bool IsVerify { get; set; }
}
