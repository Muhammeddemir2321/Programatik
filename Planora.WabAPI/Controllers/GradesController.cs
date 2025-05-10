using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.GradeFeatures.Commands;
using Planora.Application.Features.GradeFeatures.Dtos;
using Planora.Application.Features.GradeFeatures.Models;
using Planora.Application.Features.GradeFeatures.Queries;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Application.Features.LectureFeature.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllGradeByDynamicQuery getListGradeQuery = new() { PageRequest = pageRequest, Query = query };
            GradeListModel result = await Mediator.Send(getListGradeQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllGradeQuery getListGradeQuery = new() { PageRequest = pageRequest };
            GradeListModel result = await Mediator.Send(getListGradeQuery);
            return Ok(result);
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
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateGradeCommand updateGrade)
        {
            UpdatedGradeDto result = await Mediator.Send(updateGrade);
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
