using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherFeature.Models;
using Planora.Application.Features.TeacherFeature.Queries;
using Planora.Application.Features.TeacherFeatures.Commands;
using Planora.Application.Features.TeacherFeatures.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllTeacherByDynamicQuery getListTeacherQuery = new() { PageRequest = pageRequest, Query = query };
            TeacherListModel result = await Mediator.Send(getListTeacherQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllTeacherQuery getListTeacherQuery = new() { PageRequest = pageRequest };
            TeacherListModel result = await Mediator.Send(getListTeacherQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdTeacherQuery getTeacherQuery = new() { Id = id };
            TeacherGetByIdDto getTeacherResult = await Mediator.Send(getTeacherQuery);
            return Ok(getTeacherResult);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateTeacherCommand createdTeacher)
        {
            CreatedTeacherDto result = await Mediator.Send(createdTeacher);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTeacherCommand updateTeacher)
        {
            UpdatedTeacherDto result = await Mediator.Send(updateTeacher);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteTeacherCommand deleteTeacherCommand = new() { Id = id };
            await Mediator.Send(deleteTeacherCommand);
            return NoContent();
        }
    }
}
