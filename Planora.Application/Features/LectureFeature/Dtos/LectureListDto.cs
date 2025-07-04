namespace Planora.Application.Features.LectureFeature.Dtos;

public class LectureListDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public string? Name { get; set; }
}
