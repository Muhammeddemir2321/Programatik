namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public class LessonSlot
{
    public string? TeacherName { get; set; }
    public string? LectureName { get; set; }
    public Guid? LectureId { get; set; }
    public Guid? TeacherId { get; set; }
    public bool IsEmpty => !TeacherId.HasValue && !LectureId.HasValue;
}
