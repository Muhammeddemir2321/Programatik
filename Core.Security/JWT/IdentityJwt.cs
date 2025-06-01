using Core.Security.Entities;

namespace Core.Security.JWT;

public class IdentityJwt
{
    public Identity Identity { get; set; }
    public Guid SchoolId { get; set; }
}
