namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;

public class TeacherUnavailableListDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
}
