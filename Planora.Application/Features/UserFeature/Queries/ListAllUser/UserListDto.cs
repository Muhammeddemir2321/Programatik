namespace Planora.Application.Features.UserFeature.Queries.ListAllUser;

public class UserListDto
{
    public Guid SchoolId { get; set; }
    public Guid IdentityId { get; set; }
    public bool IsVerify { get; set; }
}
