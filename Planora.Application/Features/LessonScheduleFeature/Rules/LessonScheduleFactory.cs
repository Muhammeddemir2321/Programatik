using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public static class LessonScheduleFactory
{
    public static LessonSchedule Create(ClassTeachingAssignment assignment, int day, int lessonIndex)
    {
        return new LessonSchedule
        {
            ClassSectionId = assignment.ClassSectionId,
            DayOfWeek = day + 1,
            LessonIndex = lessonIndex + 1,
            TeacherId = assignment.TeacherId,
            LectureId = assignment.LectureId,
            SchoolId = assignment.SchoolId,
            ClassSectionName = assignment.ClassSectionName,
            TeacherName = assignment.TeacherName,
            LectureName = assignment.LectureName
        };
    }
}
