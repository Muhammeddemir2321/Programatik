using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;
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
            Text = $"{g.FirstName}  {g.LastName}"
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
        var newSlots = model.UnavailableSlots;
        var existingSlots = await _teacherUnavailableApiService.GetUnavailableByTeacherIdAsync(model.TeacherId);

        // Aynı gün için gelen yeni kayıtlar
        foreach (var newSlot in newSlots)
        {
            var existing = existingSlots.FirstOrDefault(e => e.DayOfWeek == newSlot.DayOfWeek);
            if (existing == null)
            {
                // ✅ Yeni gün – kaydet
                await _teacherUnavailableApiService.SaveAsync(new CreateTeacherUnavailableCommand
                {
                    TeacherId = model.TeacherId,
                    DayOfWeek = newSlot.DayOfWeek,
                    StartHour = newSlot.StartHour,
                    EndHour = newSlot.EndHour
                });
            }
            else if (existing.StartHour != newSlot.StartHour || existing.EndHour != newSlot.EndHour)
            {
                // 🔁 Güncellenmiş – update et
                await _teacherUnavailableApiService.UpdateAsync(new UpdateTeacherUnavailableCommand
                {
                    Id = existing.Id, // mevcut kaydın ID'si olmalı
                    TeacherId = model.TeacherId,
                    DayOfWeek = newSlot.DayOfWeek,
                    StartHour = newSlot.StartHour,
                    EndHour = newSlot.EndHour
                });
            }
        }

        // ❌ Artık seçilmemiş günler – sil
        foreach (var oldSlot in existingSlots)
        {
            if (!newSlots.Any(s => s.DayOfWeek == oldSlot.DayOfWeek))
            {
                await _teacherUnavailableApiService.DeleteAsync(oldSlot.Id);
            }
        }

        return RedirectToAction("Index", new { teacherId = model.TeacherId });
    }



}