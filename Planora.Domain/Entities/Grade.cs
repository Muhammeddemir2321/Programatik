using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class Grade : Entity<Guid>
{
    public string Name { get; set; }

    public  ICollection<ClassSection> ClassSections { get; set; }

    public Grade()
    {
        ClassSections = new HashSet<ClassSection>();
    }
}

