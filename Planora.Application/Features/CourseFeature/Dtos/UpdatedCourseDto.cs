namespace Planora.Application.Features.CourseFeature.Dtos;

public class UpdatedCourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? WeeklyHours { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
}
