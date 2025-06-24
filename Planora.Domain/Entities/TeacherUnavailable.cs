using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class TeacherUnavailable : Entity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
}
