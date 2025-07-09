namespace Planora.Web.Models;

public class TeacherScheduleViewModel
{
    public string TeacherName { get; set; } = string.Empty;
    public List<TeacherLessonRow> Rows { get; set; } = new();
}

public class TeacherLessonRow
{
    public int LessonIndex { get; set; } 
    public List<string> LessonsPerDay { get; set; } = new();
}
