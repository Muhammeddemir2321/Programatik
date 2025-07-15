namespace Planora.Web.Models;

public class TeacherUnavailableViewModel
{
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
    public List<TeacherUnavailableSlot> UnavailableSlots { get; set; } = new();
}
public class TeacherUnavailableSlot
{
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
}

