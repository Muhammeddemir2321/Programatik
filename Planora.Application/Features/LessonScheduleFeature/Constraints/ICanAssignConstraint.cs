using Planora.Application.Features.LessonScheduleFeature.Scheduling;

namespace Planora.Application.Features.LessonScheduleFeature.Constraints;

public interface ICanAssignConstraint
{
    string Name { get; }
    bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId);
}
