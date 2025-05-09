using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class ClassSection : Entity<Guid>
{
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public Guid GradeId { get; set; }

    public  School School { get; set; }
    public  Grade Grade { get; set; }

    public  ICollection<ClassCourseAssignment> ClassCourseAssignments { get; set; }

    public ClassSection()
    {
        ClassCourseAssignments = new HashSet<ClassCourseAssignment>();
    }
}
