namespace Planora.Web.Models;

public class ClassScheduleViewModel
{
    public string ClassName { get; set; } = string.Empty;
    public List<LessonRow> Rows { get; set; } = new();
}

public class LessonRow
{
    public int LessonIndex { get; set; }
    public List<string> LessonsPerDay { get; set; } = new();
}
