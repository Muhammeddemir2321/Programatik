using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Scheduling;

public static class LessonScheduleFactory
{
    public static LessonSchedule Create(Guid lessonScheduleGroupId, ClassTeachingAssignment assignment, int day, int lessonIndex)
    {
        return new LessonSchedule
        {
            LessonScheduleGroupId = lessonScheduleGroupId,
            ClassSectionId = assignment.ClassSectionId,
            DayOfWeek = day + 1,
            LessonIndex = lessonIndex + 1,
            TeacherId = assignment.TeacherId,
            LectureId = assignment.LectureId,
            SchoolId = assignment.SchoolId,
            ClassSectionName = assignment.ClassSectionName,
            TeacherFirstName = assignment.TeacherFirstName,
            TeacherLastName = assignment.TeacherLastName,
            LectureName = assignment.LectureName
        };
    }
}
