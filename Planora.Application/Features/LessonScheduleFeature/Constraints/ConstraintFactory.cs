using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class ConstraintFactory
{
    private readonly Dictionary<Guid, LessonSlot[,]> _weeklyGrid;
    private readonly List<TeacherUnavailable> _teacherUnavailable;

    public ConstraintFactory(Dictionary<Guid, LessonSlot[,]> weeklyGrid, List<TeacherUnavailable> teacherUnavailable)
    {
        _weeklyGrid = weeklyGrid;
        _teacherUnavailable = teacherUnavailable;
    }

    public Dictionary<string, Func<ICanAssignConstraint>> GetConstraintMap()
    {
        return new Dictionary<string, Func<ICanAssignConstraint>>
        {
            { ConstraintNamesConstant.TeacherUnavailableConstraint, () => new TeacherUnavailableConstraint(_teacherUnavailable) },
            { ConstraintNamesConstant.TeacherDailyLessonLimitConstraint, () => new TeacherDailyLessonLimitConstraint(maxPerDay: 5, _weeklyGrid) },
            { ConstraintNamesConstant.TeacherConflictConstraint, () => new TeacherConflictConstraint(_weeklyGrid) },
            { ConstraintNamesConstant.ConsecutiveLessonConstraint, () => new ConsecutiveLessonConstraint(maxConsecutive: 2) },
            { ConstraintNamesConstant.MaxSameDayLessonConstraint, () => new MaxSameDayLessonConstraint(maxSameDayLesson: 4) }
        };
    }
}
