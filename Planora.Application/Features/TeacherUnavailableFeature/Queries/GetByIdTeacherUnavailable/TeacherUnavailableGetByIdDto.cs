using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;

public class TeacherUnavailableGetByIdDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
}
