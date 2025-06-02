using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Application.Features.LectureFeature.Queries;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LecturesController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllLectureByDynamicQuery getListLectureQuery = new() { PageRequest = pageRequest, Query = query };
        LectureListModel result = await Mediator.Send(getListLectureQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllLectureQuery getListLectureQuery = new() { PageRequest = pageRequest };
        LectureListModel result = await Mediator.Send(getListLectureQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdLectureQuery getLectureQuery = new() { Id = id };
        LectureGetByIdDto getLectureResult = await Mediator.Send(getLectureQuery);
        return Ok(getLectureResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateLectureCommand createdLecture)
    {
        CreatedLectureDto result = await Mediator.Send(createdLecture);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateLectureCommand updateLecture)
    {
        UpdatedLectureDto result = await Mediator.Send(updateLecture);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteLectureCommand deleteLectureCommand = new() { Id = id };
        await Mediator.Send(deleteLectureCommand);
        return NoContent();
    }
}
