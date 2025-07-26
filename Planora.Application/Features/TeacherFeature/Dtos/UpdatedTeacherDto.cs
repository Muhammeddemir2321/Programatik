namespace Planora.Application.Features.TeacherFeature.Dtos;

public class UpdatedTeacherDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
}
