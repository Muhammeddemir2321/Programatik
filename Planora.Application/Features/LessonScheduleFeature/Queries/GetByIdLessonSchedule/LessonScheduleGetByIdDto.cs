namespace Planora.Application.Features.LessonScheduleFeature.Queries.GetByIdLessonSchedule;

public class LessonScheduleGetByIdDto
{
    public Guid ClassSectionId { get; set; }
    public int DayOfWeek { get; set; }
    public int LessonIndex { get; set; }
    public Guid TeacherId { get; set; }
    public Guid LectureId { get; set; }
    public string ClassSectionName { get; set; }
    public string TeacherName { get; set; }
    public string LectureName { get; set; }
}
