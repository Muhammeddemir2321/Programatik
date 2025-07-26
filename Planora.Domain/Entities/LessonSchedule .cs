using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class LessonSchedule : Entity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public Guid LessonScheduleGroupId { get; set; }
    public LessonScheduleGroup LessonScheduleGroup { get; set; }
    public Guid ClassSectionId { get; set; }
    public ClassSection ClassSection { get; set; }
    public int DayOfWeek { get; set; }         // Pazartesi = 1, Salı = 2, ...
    public int LessonIndex { get; set; }       // Gün içindeki ders saati (1 → 08:30, 2 → 09:25 ...)
    public Guid TeacherId { get; set; }    
    public Teacher Teacher { get; set; }
    public Guid LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public string ClassSectionName { get; set; }
    public string TeacherFirstName { get; set; }
    public string TeacherLastName { get; set; }
    public string LectureName { get; set; }
}