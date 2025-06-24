using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class MaxSameDayLessonConstraint : ICanAssignConstraint //Aynı gün aynı dersten kaç tane olabilir kısıtlaması
{
    private readonly int _maxSameDayLesson;
    public MaxSameDayLessonConstraint(int maxSameDayLesson)
    {
        _maxSameDayLesson = maxSameDayLesson;
    }

    public string Name => ConstraintNamesConstant.MaxSameDayLessonConstraint;

    public bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        int sameDayCount = 0;
        for (int hr = 0; hr < grid.GetLength(1); hr++)
        {
            if (grid[day, hr]?.LectureId == lectureId)
                sameDayCount++;
        }

        return sameDayCount >= _maxSameDayLesson;
    } //return true ise slota ekleyemezsin
}
