using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Lecture : Entity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<LessonSchedule> LessonSchedules { get; set; }
    public ICollection<ClassTeachingAssignment> ClassTeachingAssignments { get; set; }
    public Lecture()
    {
        Teachers = new HashSet<Teacher>();
        LessonSchedules = new HashSet<LessonSchedule>();
        ClassTeachingAssignments = new HashSet<ClassTeachingAssignment>();
    }
}
