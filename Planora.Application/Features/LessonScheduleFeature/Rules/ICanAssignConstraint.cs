namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public interface ICanAssignConstraint
{
    string Name { get; }
    bool CanAssign(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId);
}
