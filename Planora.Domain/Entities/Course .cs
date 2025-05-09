using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public string? WeeklyHours { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }

    public  School School { get; set; }
    public  Lecture Lecture { get; set; }

    public  ICollection<ClassCourseAssignment> ClassCourseAssignments { get; set; }

    public Course()
    {
        ClassCourseAssignments = new HashSet<ClassCourseAssignment>();
    }
}

