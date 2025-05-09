using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Teacher : Entity<Guid>
{
    public string FullName { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }

    public  School School { get; set; }
    public  Lecture Lecture { get; set; }

    public  ICollection<ClassCourseAssignment> ClassCourseAssignments { get; set; }

    public Teacher()
    {
        ClassCourseAssignments = new HashSet<ClassCourseAssignment>();
    }
}

