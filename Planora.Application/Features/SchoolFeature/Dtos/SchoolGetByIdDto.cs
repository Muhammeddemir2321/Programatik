namespace Planora.Application.Features.SchoolFeature.Dtos;

public class SchoolGetByIdDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}
