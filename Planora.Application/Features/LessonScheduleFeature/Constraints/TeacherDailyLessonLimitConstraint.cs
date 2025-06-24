using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class TeacherDailyLessonLimitConstraint : ICanAssignConstraint // Öğretmenin gün içinde kaç tane derse girebilir kontrolü
{
    private readonly int _maxPerDay;
    private readonly Dictionary<Guid, LessonSlot[,]> _allGrid;

    public TeacherDailyLessonLimitConstraint(int maxPerDay, Dictionary<Guid, LessonSlot[,]> allGrid)
    {
        _maxPerDay = maxPerDay;
        _allGrid = allGrid;
    }

    public string Name => ConstraintNamesConstant.TeacherDailyLessonLimitConstraint;

    public bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        int count = 0;
        foreach (var g in _allGrid.Values)
        {
            for (int h = 0; h < grid.GetLength(1); h++)
            {
                if (g[day, h] != null && g[day, h].TeacherId == teacherId)
                    count++;
            }
        }

        return count < _maxPerDay;
    } //return true ise slota ekleyebilirsn
}
