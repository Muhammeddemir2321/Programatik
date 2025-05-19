namespace Planora.Application.Features.UserFeature.Queries.GetByIdUser;

public class UserGetByIdDto
{
    public Guid SchoolId { get; set; }
    public Guid BaseUserId { get; set; }
    public bool IsVerify { get; set; }
}
