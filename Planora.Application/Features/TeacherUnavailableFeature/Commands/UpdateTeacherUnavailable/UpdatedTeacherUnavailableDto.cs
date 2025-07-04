using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;

public class UpdatedTeacherUnavailableDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
}
