using Core.Persistence.Repositories;

namespace Planora.Domain.Entities;

public class LectureDistributionOption : Entity<Guid>, ISchoolEntity
{
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public int TotalHours { get; set; }
    public string Distribution { get; set; } = string.Empty;
}
