using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Scheduling;

public interface ILessonScheduler
{
    List<LessonSchedule> GenerateSchedule(
        SlotFinder slotFinder,
        List<ClassTeachingAssignment> allAssignments,
        List<ClassSection> classSections);
}
