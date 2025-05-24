namespace Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;

public class UpdatedIdentityDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}
