using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public class ConsecutiveLessonConstraint : ICanAssignConstraint  //Aynı dersin ard arda kaç tane gelebilir kısıtlaması
{
    private readonly int _maxConsecutive;

    public ConsecutiveLessonConstraint(int maxConsecutive)
    {
        _maxConsecutive = maxConsecutive;
    }

    public string Name => ConstraintNamesConstant.ConsecutiveLessonConstraint;

    public bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        int consecutive = 0;

        for (int h = 0; h < grid.GetLength(1); h++)
        {
            var slot = grid[day, h];
            if (slot != null && slot.TeacherId == teacherId)
            {
                consecutive++;
                if (consecutive >= _maxConsecutive)
                    return false;
            }
            else
            {
                consecutive = 0;
            }
        }

        return true;
    }
}
