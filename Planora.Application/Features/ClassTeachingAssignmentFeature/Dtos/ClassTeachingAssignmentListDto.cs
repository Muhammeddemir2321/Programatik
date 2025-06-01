namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;

public class ClassTeachingAssignmentListDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    public int WeeklyHourCount { get; set; }
}
