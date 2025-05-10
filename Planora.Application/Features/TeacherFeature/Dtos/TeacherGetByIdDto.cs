namespace Planora.Application.Features.TeacherFeature.Dtos;

public class TeacherGetByIdDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
}
