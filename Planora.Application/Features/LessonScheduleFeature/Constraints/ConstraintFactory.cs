using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class ConstraintFactory
{
    private readonly Dictionary<Guid, LessonSlot[,]> _weeklyGrid;

    public ConstraintFactory(Dictionary<Guid, LessonSlot[,]> weeklyGrid)
    {
        _weeklyGrid = weeklyGrid;
    }

    public Dictionary<string, Func<ICanAssignConstraint>> GetConstraintMap()
    {
        var teacherUnavailable = new List<TeacherUnavailable>();
        return new Dictionary<string, Func<ICanAssignConstraint>>
        {
            { ConstraintNamesConstant.TeacherUnavailableConstraint, () => new TeacherUnavailableConstraint(teacherUnavailable) },
            { ConstraintNamesConstant.TeacherDailyLessonLimitConstraint, () => new TeacherDailyLessonLimitConstraint(maxPerDay: 5, _weeklyGrid) },
            { ConstraintNamesConstant.TeacherConflictConstraint, () => new TeacherConflictConstraint(_weeklyGrid) },
            { ConstraintNamesConstant.ConsecutiveLessonConstraint, () => new ConsecutiveLessonConstraint(maxConsecutive: 2) },
            { ConstraintNamesConstant.MaxSameDayLessonConstraint, () => new MaxSameDayLessonConstraint(maxSameDayLesson: 4) }
        };
    }
}
