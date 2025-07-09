using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Web.Models;
using Planora.Web.Services;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Planora.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LessonScheduleGroupApiService _groupApiService;
        public HomeController(LessonScheduleGroupApiService groupApiService, ILogger<HomeController> logger)
        {
            _groupApiService = groupApiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var allConstraints = new List<(string Key, string Display)>
            {
                (ConstraintNamesConstant.TeacherConflictConstraint, "Öðretmen Çakýþma Kontrolü"),
                (ConstraintNamesConstant.TeacherUnavailableConstraint, "Öðretmen Müsaitlik Kontrolü"),
                (ConstraintNamesConstant.TeacherDailyLessonLimitConstraint, "Günlük Öðretmen Ders Sayýsý Kontrolü"),
                (ConstraintNamesConstant.ConsecutiveLessonConstraint, "Arka Arkaya Ayný Dersten Olma Kontrolü"),
                (ConstraintNamesConstant.MaxSameDayLessonConstraint, "Ayný Günde Ayný Dersten Olma Kontrolü")
            };

            ViewBag.AllConstraints = allConstraints;

            var allGroups = await _groupApiService.GetAllAsync();

            ViewBag.LessonGroups = allGroups.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = $"{g.Year} / {g.Semester} - {g.Description}"
            }).ToList();

            return View(new ScheduleOptionsViewModel());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
