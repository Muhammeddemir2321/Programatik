using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;

public class SchoolScheduleSettingGetByIdDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public TimeSpan FirstLessonStartTime { get; set; }
    public int LessonDurationMinutes { get; set; }
    public int BreakDurationMinutes { get; set; }
    public int DailyLessonCount { get; set; }
}
