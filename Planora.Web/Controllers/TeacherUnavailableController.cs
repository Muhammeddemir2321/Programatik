using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Web.Models;
using Planora.Web.Services;

namespace Planora.Web.Controllers;

public class TeacherUnavailableController : Controller
{
    private readonly TeacherUnavailableApiService _teacherUnavailableApiService;

    public TeacherUnavailableController(TeacherUnavailableApiService teacherUnavailableApiService)
    {
        _teacherUnavailableApiService = teacherUnavailableApiService;
    }

    public async Task<IActionResult> Index(Guid? teacherId)
    {
        var allTeachers = await _teacherUnavailableApiService.GetListTeacherAllAsync();

        ViewBag.Teachers = allTeachers.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.FullName}"
        }).ToList();

        var model = new TeacherUnavailableViewModel();

        if (teacherId.HasValue && teacherId != Guid.Empty)
        {
            var settings = await _teacherUnavailableApiService.GetUnavailableByTeacherIdAsync(teacherId.Value);
            model.TeacherId = teacherId.Value;
            model.UnavailableSlots = settings.Select(s => new TeacherUnavailableSlot
            {
                DayOfWeek = s.DayOfWeek,
                StartHour = s.StartHour,
                EndHour = s.EndHour
            }).ToList();
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacherUnavailable(TeacherUnavailableViewModel model)
    {
        var commands = model.UnavailableSlots.Select(slot => new CreateTeacherUnavailableCommand
        {
            TeacherId = model.TeacherId,
            DayOfWeek = slot.DayOfWeek,
            StartHour = slot.StartHour,
            EndHour = slot.EndHour
        }).ToList();

        foreach (var command in commands)
        {
            await _teacherUnavailableApiService.SaveAsync(command);
        }

        return RedirectToAction("Index", new { teacherId = model.TeacherId });
    }


}