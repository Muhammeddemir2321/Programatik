using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class ClassCourseAssignment : Entity<Guid>, ISchoolEntity
{
    public Guid ClassSectionId { get; set; }
    public Guid CourseId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid SchoolId { get; set; }

    public  ClassSection ClassSection { get; set; }
    public  Course Course { get; set; }
    public Teacher Teacher { get; set; }
    public School School { get; set; }
    public string? ScheduleInfo { get; set; }
}

