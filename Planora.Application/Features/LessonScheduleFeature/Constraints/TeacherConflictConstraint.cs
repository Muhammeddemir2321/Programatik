using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Rules;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class TeacherConflictConstraint : ICanAssignConstraint //Öğretmenin o saatte başka sınıfta dersi var mı kontrolü
{
    private readonly Dictionary<Guid, LessonSlot[,]> _allGrids;

    public TeacherConflictConstraint(Dictionary<Guid, LessonSlot[,]> allGrids)
    {
        _allGrids = allGrids;
    }

    public string Name => ConstraintNamesConstant.TeacherConflictConstraint;

    public bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        return !_allGrids.Values.Any(g =>
        {
            var slot = g[day, hour];
            return slot != null && slot.TeacherId == teacherId;
        });
    }  //return true ise slota ekleyebilirsn
}
