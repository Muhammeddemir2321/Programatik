﻿using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Web.Models;
using Planora.Web.Services;

namespace Planora.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly LessonScheduleGroupApiService _groupApiService;
        public ScheduleController(LessonScheduleGroupApiService groupApiService)
        {
            _groupApiService = groupApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLessonSchedulesByGroupId(Guid groupId, string viewType = "class")
        {
            if (groupId == Guid.Empty)
                return RedirectToAction("Index", "Home");

            var result = await _groupApiService.GetAsync(groupId);
            if (result == null)
            {
                TempData["Error"] = "Ders programı bulunamadı.";
                return RedirectToAction("Index", "Home");
            }

            var schedules = result.listAllLessonScheduleGetByGroupIdDtos;
            var classSections = result.classSectionListDtos;
            var teachers = result.teacherListDtos;
            var settings = result.SchoolScheduleSettingGetByIdDto;

            if (viewType == "teacher")
            {
                var teacherViewModels = teachers.Select(teacher =>
                {
                    var teacherVm = new TeacherScheduleViewModel
                    {
                        TeacherFirstName = teacher.FirstName,
                        TeacherLastName = teacher.LastName
                    };

                    for (int i = 0; i < settings.DailyLessonCount; i++)
                    {
                        var row = new TeacherLessonRow { LessonIndex = i + 1 };

                        for (int j = 0; j < settings.WeeklyLessonDayCount; j++)
                        {
                            var matching = schedules.FirstOrDefault(s =>
                                s.TeacherId == teacher.Id &&
                                s.DayOfWeek == j + 1 &&
                                s.LessonIndex == i + 1);

                            if (matching == null)
                                row.LessonsPerDay.Add("Boş");
                            else
                                row.LessonsPerDay.Add($"{matching.LectureName} – {matching.ClassSectionName}");
                        }

                        teacherVm.Rows.Add(row);
                    }

                    return teacherVm;
                }).ToList();

                return View("TeacherSchedule", teacherViewModels);
            }

            var classViewModels = classSections.Select(classs =>
            {
                var vm = new ClassScheduleViewModel { ClassName = classs.Name };

                for (int i = 0; i < settings.DailyLessonCount; i++)
                {
                    var row = new LessonRow { LessonIndex = i + 1 };

                    for (int j = 0; j < settings.WeeklyLessonDayCount; j++)
                    {
                        var schedule = schedules.FirstOrDefault(s =>
                            s.ClassSectionId == classs.Id &&
                            s.DayOfWeek == j + 1 &&
                            s.LessonIndex == i + 1);

                        if (schedule == null)
                        {
                            row.LessonsPerDay.Add("Boş");
                        }
                        else
                        {
                            row.LessonsPerDay.Add($"{schedule.LectureName} – {schedule.TeacherName}");
                        }
                    }

                    vm.Rows.Add(row);
                }

                return vm;
            }).ToList();

            return View("ClassSchedule", classViewModels);
        }


        [HttpPost]
        public async Task<IActionResult> CreateLessonSchedule(ScheduleOptionsViewModel model)
        {
            var command = new CreateLessonScheduleGroupCommand
            {
                Semester = model.Semester,
                Year = model.Year,
                Description = model.Description,
                createLessonScheduleCommand = new CreateLessonScheduleCommand
                {
                    SelectedConstraintNames = model.SelectedConstraintNames
                }
            };
            var result = await _groupApiService.SaveAsync(command);
            if (result == null)
            {
                TempData["Error"] = "Ders programı oluşturulurken bir hata oluştu.";
                return RedirectToAction("Index");
            }
            var schedules = result.CreatedLessonScheduleDtos;
            var classSections = result.classSectionListDtos;
            var settings = result.SchoolScheduleSettingGetByIdDto;


            var viewModels = classSections.Select(classs =>
            {
                var vm = new ClassScheduleViewModel { ClassName = classs.Name };

                for (int i = 0; i < settings.DailyLessonCount; i++)
                {
                    var row = new LessonRow { LessonIndex = i + 1 };

                    for (int j = 0; j < settings.WeeklyLessonDayCount; j++)
                    {
                        var schedule = schedules.FirstOrDefault(s =>
                            s.ClassSectionId == classs.Id &&
                            s.DayOfWeek == j + 1 &&
                            s.LessonIndex == i + 1);

                        if (schedule == null)
                        {
                            row.LessonsPerDay.Add("Boş");
                        }
                        else
                        {
                            row.LessonsPerDay.Add($"{schedule.LectureName} – {schedule.TeacherName}");
                        }
                    }

                    vm.Rows.Add(row);
                }

                return vm;
            }).ToList();


            return View("Index", viewModels);
        }
    }
}
