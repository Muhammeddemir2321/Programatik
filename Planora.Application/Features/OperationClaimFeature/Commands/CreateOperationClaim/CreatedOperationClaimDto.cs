namespace Planora.Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;

public class CreatedOperationClaimDto
{
    public Guid Id { get; set; }
    public string Group { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
