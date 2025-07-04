namespace Planora.Application.Features.LectureFeature.Dtos;

public class UpdatedLectureDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public string? Name { get; set; }
}
