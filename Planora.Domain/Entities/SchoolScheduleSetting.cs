using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class SchoolScheduleSetting : Entity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public TimeSpan FirstLessonStartTime { get; set; }
    public int LessonDurationMinutes { get; set; } 
    public int BreakDurationMinutes { get; set; } 
    public int DailyLessonCount { get; set; } 
}

