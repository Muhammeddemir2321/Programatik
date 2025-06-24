using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public class SlotFinder
{
    public Dictionary<Guid, LessonSlot[,]> _grids;
    private readonly int _weeklyLessonDayCount;
    private readonly int _dailyLessonCount;
    private readonly ConstraintManager _constraintManager;

    public SlotFinder(ConstraintManager constraintManager, Dictionary<Guid, LessonSlot[,]> grids, int weeklyLessonDayCount, int dailyLessonCount)
    {
        _constraintManager = constraintManager;
        _grids = grids;
        _weeklyLessonDayCount = weeklyLessonDayCount;
        _dailyLessonCount = dailyLessonCount;
    }
    public List<LessonSchedule>? FindNextAvailableSlot(ClassTeachingAssignment assignment)
    {
        var suggestedSchedules = new List<LessonSchedule>();
        var classGrid = _grids[assignment.ClassSectionId];

        var lectureHourDistribution = LectureDistributionStrategy.GetDefault(assignment.WeeklyHourCount);
        var randomizedDays = Enumerable.Range(0, _weeklyLessonDayCount).OrderBy(_ => Guid.NewGuid()).ToList();

        foreach (var day in randomizedDays)
        {
            foreach (var blockHourCount in lectureHourDistribution.ToList())
            {
                var startHour = FindContinuousFreeBlock(classGrid, day, blockHourCount, assignment);
                if (startHour == -1)
                    continue;

                for (int offset = 0; offset < blockHourCount; offset++)
                {
                    classGrid[day, startHour + offset] = new LessonSlot
                    {
                        TeacherId = assignment.TeacherId,
                        LectureId = assignment.LectureId
                    };

                    var schedule = LessonScheduleFactory.Create(assignment, day, startHour + offset);
                    suggestedSchedules.Add(schedule);
                }

                lectureHourDistribution.Remove(blockHourCount);

                if (suggestedSchedules.Count == assignment.WeeklyHourCount)
                {
                    _grids[assignment.ClassSectionId] = classGrid;
                    return suggestedSchedules;
                }
                break;
            }
        }

        return null;
    }
    private int FindContinuousFreeBlock(LessonSlot[,] grid, int day, int requiredBlockLength, ClassTeachingAssignment assignment)
    {
        int consecutiveFree = 0;
        for (int hour = 0; hour < _dailyLessonCount; hour++)
        {
            var slot = grid[day, hour];
            bool isAvailable = (slot == null || slot.IsEmpty) &&
                !_constraintManager.Check(ConstraintNamesConstant.TeacherUnavailableConstraint, grid, day, hour, assignment.TeacherId, assignment.LectureId) &&
                _constraintManager.Check(ConstraintNamesConstant.TeacherConflictConstraint, grid, day, hour, assignment.TeacherId, assignment.LectureId);

            if (isAvailable)
            {
                consecutiveFree++;
                if (consecutiveFree == requiredBlockLength)
                    return hour - requiredBlockLength + 1;            // Blok başlangıç saati
            }
            else
            {
                consecutiveFree = 0;
            }
        }

        return -1;     // Uygun blok bulunamadı 
    }

}
