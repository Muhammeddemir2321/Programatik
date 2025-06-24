namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public class ConstraintManager
{
    private readonly Dictionary<string, ICanAssignConstraint> _constraints;

    public ConstraintManager(IEnumerable<ICanAssignConstraint> constraints)
    {
        _constraints = constraints.ToDictionary(c => c.Name);
    }

    public bool Check(string name, LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        if (_constraints.TryGetValue(name, out var constraint))
        {
            return constraint.CanAssign(grid, day, hour, teacherId, lectureId);
        }

        //throw new ArgumentException($"Constraint not found: {name}");
        return false;
    }

    public bool CheckAll(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        return _constraints.Values.All(c => c.CanAssign(grid, day, hour, teacherId, lectureId));
    }

    public Dictionary<string, bool> CheckAllWithResults(LessonSlot[,] grid, int day, int hour, Guid teacherId, Guid lectureId)
    {
        return _constraints.ToDictionary(
            c => c.Key,
            c => c.Value.CanAssign(grid, day, hour, teacherId, lectureId)
        );
    }
}
