using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class School : Entity<Guid>
{
    public string Name { get; set; }
    public string? Address { get; set; }

    public  ICollection<ClassSection> ClassSections { get; set; }
    public  ICollection<Teacher> Teachers { get; set; }
    public  ICollection<ClassTeachingAssignment> ClassTeachingAssignments { get; set; }
    public  ICollection<LessonSchedule> LessonSchedules { get; set; }
    public  ICollection<User> Users { get; set; }

    public School()
    {
        ClassSections = new HashSet<ClassSection>();
        Teachers = new HashSet<Teacher>();
        ClassTeachingAssignments = new HashSet<ClassTeachingAssignment>();
        LessonSchedules = new HashSet<LessonSchedule>();
        Users = new HashSet<User>();
    }
}

