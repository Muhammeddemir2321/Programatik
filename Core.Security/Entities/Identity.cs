using Microsoft.AspNetCore.Identity;

namespace Core.Security.Entities;

public class Identity : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? CreatedUserId { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
}
