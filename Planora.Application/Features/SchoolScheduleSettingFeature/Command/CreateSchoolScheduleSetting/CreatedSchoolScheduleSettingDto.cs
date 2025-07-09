namespace Planora.Application.Features.SchoolScheduleSettingFeature.Command.CreateSchoolScheduleSetting;

public class CreatedSchoolScheduleSettingDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public TimeSpan FirstLessonStartTime { get; set; }
    public int LessonDurationMinutes { get; set; }
    public int BreakDurationMinutes { get; set; }
    public int WeeklyLessonDayCount { get; set; }
    public int DailyLessonCount { get; set; }
}
