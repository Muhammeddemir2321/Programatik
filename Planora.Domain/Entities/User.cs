namespace Planora.Domain.Entities;

using Core.Persistence.Repositories;
using Core.Security.Entities;

public class User : BaseTimeStampEntity<Guid>, ISchoolEntity
{

    public Guid SchoolId { get; set; }
    public School School { get; set; }

    public Guid BaseUserId { get; set; }
    public BaseUser BaseUser { get; set; }
    public bool IsVerify { get; set; }

} 