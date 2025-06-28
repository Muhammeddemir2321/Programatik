namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class LessonScheduleGroupGetByIdDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
