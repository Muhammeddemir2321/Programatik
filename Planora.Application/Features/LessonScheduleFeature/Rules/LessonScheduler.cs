using Planora.Application.Features.LessonScheduleFeature.Logs;
using Planora.Domain.Entities;
using System.Collections.Generic;

namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public class LessonScheduler
{
    public List<LessonSchedule> GenerateSchedule(
        SlotFinder slotFinder,
        List<ClassTeachingAssignment> allAssignments,
        List<ClassSection> classSections)
    {
        var result = new List<LessonSchedule>();
        int essayCount = 1;

        do
        {
            CustomLog.WriteLogsToFile($"🛠 Yeni Plan Denemesi Başlıyor ({essayCount++})");
            result.Clear();

            ClearGrids(slotFinder._grids);
            bool allSuccessful = true;

            foreach (var classSection in classSections)
            {
                bool success = TryScheduleAssignmentsForClass(slotFinder, classSection.Id, allAssignments, out var classSchedules);

                if (success)
                {
                    CustomLog.WriteLogsToFile($"✅ {classSection.Name} başarıyla yerleştirildi.");
                    result.AddRange(classSchedules);
                }
                else
                {
                    CustomLog.WriteLogsToFile($"⚠️ {classSection.Name} sınıfı için planlama başarısız. Retry devreye giriyor...");

                    int retryCount = 0;
                    bool retrySuccess = false;

                    while (retryCount < 500 && !retrySuccess)
                    {

                        CustomLog.WriteLogsToFile($"🔁 Retry başlatıldı → {classSection.Name} sınıfı {retryCount + 1}. deneme");

                        retrySuccess = TryScheduleAssignmentsForClass(slotFinder, classSection.Id, allAssignments, out classSchedules);
                        retryCount++;
                        if (retrySuccess)
                        {
                            CustomLog.WriteLogsToFile($"✅ {classSection.Name} başarıyla yerleştirildi.");
                            result.AddRange(classSchedules);
                        }
                    }

                    if (!retrySuccess)
                    {
                        CustomLog.WriteLogsToFile($"⛔ Retry başarısız oldu: {classSection.Name} sınıfı yerleştirilemedi.");
                        allSuccessful = false;
                        break;
                    }
                }
            }

            if (allSuccessful)
                return result;

        } while (essayCount < 100);

        CustomLog.WriteLogsToFile("🚨 Tüm planlama denemeleri başarısız oldu.");
        return result;
    }

    private bool TryScheduleAssignmentsForClass(
        SlotFinder slotFinder,
        Guid classSectionId,
        List<ClassTeachingAssignment> allAssignments,
        out List<LessonSchedule> schedules)
    {
        int totalLessonHours = 0;
        schedules = new List<LessonSchedule>();
        slotFinder._grids[classSectionId] = new LessonSlot[5, 8];

        var teacherLoadMap = allAssignments
            .GroupBy(a => a.TeacherId)
            .ToDictionary(g => g.Key, g => g.Sum(a => a.WeeklyHourCount));

        var classAssignments = allAssignments
            .Where(a => a.ClassSectionId == classSectionId)
            .Select(a =>
            {
                a.TeacherTotalLoad = teacherLoadMap.GetValueOrDefault(a.TeacherId, 0);
                return a;
            })
            .OrderByDescending(a => a.WeeklyHourCount)
            .ThenByDescending(a => a.TeacherTotalLoad)
            .ToList();

        foreach (var assignment in classAssignments)
        {
            var result = slotFinder.FindNextAvailableSlot(assignment);

            if (result != null)
            {
                schedules.AddRange(result);
                totalLessonHours += assignment.WeeklyHourCount;
            }
            else
            {

                CustomLog.WriteLogsToFile($"{totalLessonHours} saatlik dersler eklendikten sonra çakışma yaşandı");
                return false;
            }
        }

        return true;
    }

    private void ClearGrids(Dictionary<Guid, LessonSlot[,]> grids)
    {
        foreach (var key in grids.Keys.ToList())
        {
            grids[key] = new LessonSlot[5, 8];
        }
    }

}
