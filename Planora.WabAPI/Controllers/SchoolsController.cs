using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.SchoolFeature.Commands;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Models;
using Planora.Application.Features.SchoolFeature.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllSchoolByDynamicQuery getListSchoolQuery = new() { PageRequest = pageRequest, Query = query };
            SchoolListModel result = await Mediator.Send(getListSchoolQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllSchoolQuery getListSchoolQuery = new() { PageRequest = pageRequest };
            SchoolListModel result = await Mediator.Send(getListSchoolQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdSchoolQuery getSchoolQuery = new() { Id = id };
            SchoolGetByIdDto getSchoolResult = await Mediator.Send(getSchoolQuery);
            return Ok(getSchoolResult);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSchoolCommand createdSchool)
        {
            CreatedSchoolDto result = await Mediator.Send(createdSchool);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSchoolCommand updateSchool)
        {
            UpdatedSchoolDto result = await Mediator.Send(updateSchool);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteSchoolCommand deleteSchoolCommand = new() { Id = id };
            await Mediator.Send(deleteSchoolCommand);
            return NoContent();
        }
    }
}
