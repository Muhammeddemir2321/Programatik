using Core.Security.Entities;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Command.CreateUser;

public class CreatedUserDto
{
    public Guid SchoolId { get; set; }
    public Guid BaseUserId { get; set; }
    public bool IsVerify { get; set; }
}
