using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class TeacherUnavailableConstraint : ICanAssignConstraint // Öğretmenin o gün çalışıp çalışmadığı  kontrolü
{
    private readonly List<TeacherUnavailable> _teacherUnavailables;

    public TeacherUnavailableConstraint(List<TeacherUnavailable> teacherUnavailables)
    {
        _teacherUnavailables = teacherUnavailables;
    }

    public string Name => ConstraintNamesConstant.TeacherUnavailableConstraint;

    public bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        var blocks = _teacherUnavailables.Where(u => u.TeacherId == teacherId && u.DayOfWeek == day + 1);

        foreach (var block in blocks)
        {
            if (block.StartHour == null && block.EndHour == null)
                return true;

            if (block.StartHour <= hour + 1 && hour + 1 <= block.EndHour)
                return true;
        }

        return false;
    } //return true ise slota ekleyemezsin

}
