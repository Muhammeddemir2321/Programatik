using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.DeleteTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailableByDynamic;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherUnavailablesController : BaseController
    {
        [HttpPost("GetListAll")]
        public async Task<IActionResult> GetListAll()
        {
            ListAllTeacherUnavailableQuery getListTeacherUnavailableQuery = new();
            TeacherUnavailableListModel result = await Mediator.Send(getListTeacherUnavailableQuery);
            return Ok(result.Items);
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllTeacherUnavailableByDynamicQuery getListTeacherUnavailableQuery = new() { PageRequest = pageRequest, Query = query };
            TeacherUnavailableListModel result = await Mediator.Send(getListTeacherUnavailableQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllTeacherUnavailableQuery getListTeacherUnavailableQuery = new() { PageRequest = pageRequest };
            TeacherUnavailableListModel result = await Mediator.Send(getListTeacherUnavailableQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdTeacherUnavailableQuery getTeacherUnavailableQuery = new() { Id = id };
            TeacherUnavailableGetByIdDto getTeacherUnavailableResult = await Mediator.Send(getTeacherUnavailableQuery);
            return Ok(getTeacherUnavailableResult);
        }
        [HttpGet("GetByTeacherId/{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(Guid teacherId)
        {
            GetByTeacherIdTeacherUnavailableQuery getTeacherUnavailableQuery = new() { TeacherId = teacherId };
            List<TeacherUnavailableListDto> result = await Mediator.Send(getTeacherUnavailableQuery);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateTeacherUnavailableCommand createdTeacherUnavailable)
        {
            CreatedTeacherUnavailableDto result = await Mediator.Send(createdTeacherUnavailable);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTeacherUnavailableCommand updateTeacherUnavailable)
        {
            UpdatedTeacherUnavailableDto result = await Mediator.Send(updateTeacherUnavailable);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteTeacherUnavailableCommand deleteTeacherUnavailableCommand = new() { Id = id };
            await Mediator.Send(deleteTeacherUnavailableCommand);
            return NoContent();
        }
    }
}
