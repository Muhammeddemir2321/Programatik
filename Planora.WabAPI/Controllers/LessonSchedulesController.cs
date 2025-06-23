using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.GradeFeature.Commands;
using Planora.Application.Features.GradeFeature.Dtos;
using Planora.Application.Features.GradeFeature.Models;
using Planora.Application.Features.GradeFeature.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonSchedulesController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllGradeByDynamicQuery getListGradeQuery = new() { PageRequest = pageRequest, Query = query };
            GradeListModel result = await Mediator.Send(getListGradeQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdGradeQuery getGradeQuery = new() { Id = id };
            GradeGetByIdDto getGradeResult = await Mediator.Send(getGradeQuery);
            return Ok(getGradeResult);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateGradeCommand createdGrade)
        {
            CreatedGradeDto result = await Mediator.Send(createdGrade);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteGradeCommand deleteGradeCommand = new() { Id = id };
            await Mediator.Send(deleteGradeCommand);
            return NoContent();
        }
    }
}
