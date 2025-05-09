using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class ClassCourseAssignment : Entity<Guid>
{
    public Guid ClassSectionId { get; set; }
    public Guid CourseId { get; set; }
    public Guid TeacherId { get; set; }

    public  ClassSection ClassSection { get; set; }
    public  Course Course { get; set; }
    public Teacher Teacher { get; set; }
    public string? ScheduleInfo { get; set; }
}

