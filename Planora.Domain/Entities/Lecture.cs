using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Lecture : Entity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public Lecture()
    {
        Courses = new HashSet<Course>();
        Teachers = new HashSet<Teacher>();
    }
}
