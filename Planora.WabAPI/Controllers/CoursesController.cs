using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.CourseFeature.Dtos;
using Planora.Application.Features.CourseFeature.Models;
using Planora.Application.Features.CourseFeature.Queries;
using Planora.Application.Features.CourseFeatures.Commands;
using Planora.Application.Features.CourseFeatures.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllCourseByDynamicQuery getListCourseQuery = new() { PageRequest = pageRequest, Query = query };
            CourseListModel result = await Mediator.Send(getListCourseQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllCourseQuery getListCourseQuery = new() { PageRequest = pageRequest };
            CourseListModel result = await Mediator.Send(getListCourseQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdCourseQuery getCourseQuery = new() { Id = id };
            CourseGetByIdDto getCourseResult = await Mediator.Send(getCourseQuery);
            return Ok(getCourseResult);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseCommand createdCourse)
        {
            CreatedCourseDto result = await Mediator.Send(createdCourse);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommand updateCourse)
        {
            UpdatedCourseDto result = await Mediator.Send(updateCourse);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCourseCommand deleteCourseCommand = new() { Id = id };
            await Mediator.Send(deleteCourseCommand);
            return NoContent();
        }
    }
}
