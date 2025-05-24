namespace Planora.Application.Features.UserFeature.Commands.CreateUser;

public class CreatedUserDto
{
    public Guid SchoolId { get; set; }
    public Guid IdentityId { get; set; }
    public bool IsVerify { get; set; }
}
