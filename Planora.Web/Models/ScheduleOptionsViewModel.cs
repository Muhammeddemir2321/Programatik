namespace Planora.Web.Models;

public class ScheduleOptionsViewModel
{
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public List<string> SelectedConstraintNames { get; set; } = new();
}
