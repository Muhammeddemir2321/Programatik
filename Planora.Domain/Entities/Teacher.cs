using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Teacher : Entity<Guid>, ISchoolEntity
{
    public string FullName { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }

    public  School School { get; set; }
    public  Lecture Lecture { get; set; }

    public  ICollection<LessonSchedule> LessonSchedules { get; set; }
    public  ICollection<ClassTeachingAssignment> ClassTeachingAssignments { get; set; }

    public Teacher()
    {
        LessonSchedules = new HashSet<LessonSchedule>();
        ClassTeachingAssignments = new HashSet<ClassTeachingAssignment>();
    }
}

