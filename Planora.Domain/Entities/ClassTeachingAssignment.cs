using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class ClassTeachingAssignment : Entity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public Guid LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public Guid ClassSectionId { get; set; }
    public ClassSection ClassSection { get; set; }
    public bool IsOptional { get; set; }
    public int WeeklyHourCount { get; set; }
    public int TeacherTotalLoad { get; set; }
    public string ClassSectionName { get; set; }
    public string TeacherFirstName { get; set; }
    public string TeacherLastName { get; set; }
    public string LectureName { get; set; }
}
