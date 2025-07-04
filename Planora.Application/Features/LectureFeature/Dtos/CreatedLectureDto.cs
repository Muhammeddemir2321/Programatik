namespace Planora.Application.Features.LectureFeature.Dtos;

public class CreatedLectureDto
{
    public Guid Id { get; set; }
    public  Guid SchoolId { get; set; }
    public string? Name { get; set; }
}
