using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class ClassSection : Entity<Guid>, ISchoolEntity
{
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public Guid GradeId { get; set; }

    public  School School { get; set; }
    public  Grade Grade { get; set; }

    public  ICollection<LessonSchedule> LessonSchedules { get; set; }
    public  ICollection<ClassTeachingAssignment> ClassTeachingAssignments { get; set; }

    public ClassSection()
    {
        LessonSchedules = new HashSet<LessonSchedule>();
        ClassTeachingAssignments = new HashSet<ClassTeachingAssignment>();
    }
}
