using AutoMapper;
using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Commands;
using Planora.Application.Features.SchoolScheduleSettingFeature.Commands.CreateSchoolScheduleSetting;
using Planora.Application.Features.TeacherFeatures.Commands;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Persistence.SeedData;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDatasController : BaseController
    {
        private readonly IMapper _mapper;

        public SeedDatasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("AddSchool")]
        public async Task<IActionResult> AddSchool()
        {
            var schools = SeedTestData.SetSeedDataSchool();
            foreach (var item in schools)
            {
                var command = _mapper.Map<CreateSchoolCommand>(item);
                var result = await Mediator.Send(command);
            }
            return Ok();
        }

        [HttpPost("AddSchoolScheduleSetting")]
        public async Task<IActionResult> AddSchoolScheduleSetting()
        {
            var schoolScheduleSettings = SeedTestData.SetSeedDataSchoolchoolScheduleSetting();
            foreach (var item in schoolScheduleSettings)
            {
                var command = _mapper.Map<CreateSchoolScheduleSettingCommand>(item);
                var result = await Mediator.Send(command);
            }
            return Ok();
        }
        [HttpPost("AddLectureDistribution")]
        public async Task<IActionResult> AddLectureDistribution()
        {
            var lectureDistribution = SeedTestData.SetSeedDataLectureDistributionOption();
            foreach (var item in lectureDistribution)
            {
                var command = _mapper.Map<CreateLectureDistributionOptionCommand>(item);
                var result = await Mediator.Send(command);
            }
            return Ok();
        }

        //[HttpPost("AddClassSection")]
        //public async Task<IActionResult> AddClassSection()
        //{
        //    var classSections = SeedTestData.SetSeedDataClassSection();
        //    foreach (var item in classSections)
        //    {
        //        var command = _mapper.Map<CreateClassSectionCommand>(item);
        //        var result = await Mediator.Send(command);
        //    }
        //    return Ok();
        //}

        //[HttpPost("AddTeacher")]
        //public async Task<IActionResult> AddTeacher()
        //{
        //    var teachers = SeedTestData.SetSeedDataTeacher();
        //    foreach (var item in teachers)
        //    {
        //        var command = _mapper.Map<CreateTeacherCommand>(item);
        //        var result = await Mediator.Send(command);
        //    }
        //    return Ok();
        //}
        //[HttpPost("AddTeacherUnavailable")]
        //public async Task<IActionResult> AddTeacherUnavailable()
        //{
        //    var TeacherUnavailables = SeedTestData.SetSeedDataTeacherUnavailable();
        //    foreach (var item in TeacherUnavailables)
        //    {
        //        var command = _mapper.Map<CreateTeacherUnavailableCommand>(item);
        //        var result = await Mediator.Send(command);
        //    }
        //    return Ok();
        //}
        //[HttpPost("AddLecture")]
        //public async Task<IActionResult> AddLecture()
        //{
        //    var lectures = SeedTestData.SetSeedDataLecture();
        //    foreach (var item in lectures)
        //    {
        //        var command = _mapper.Map<CreateLectureCommand>(item);
        //        var result = await Mediator.Send(command);
        //    }
        //    return Ok();
        //}
        //[HttpPost("AddClassTeachingAssignment")]
        //public async Task<IActionResult> AddClassTeachingAssignment()
        //{
        //    var classTeachingAssignments = SeedTestData.SetSeedDataClassTeachingAssignment();
        //    foreach (var item in classTeachingAssignments)
        //    {
        //        var command = _mapper.Map<CreateClassTeachingAssignmentCommand>(item);
        //        var result = await Mediator.Send(command);
        //    }
        //    return Ok();
        //}

    }
}
