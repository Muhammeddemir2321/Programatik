using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Models;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Queries;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassTeachingAssignmentsController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllClassTeachingAssignmentByDynamicQuery getListClassTeachingAssignmentQuery = new() { PageRequest = pageRequest, Query = query };
        ClassTeachingAssignmentListModel result = await Mediator.Send(getListClassTeachingAssignmentQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllClassTeachingAssignmentQuery getListClassTeachingAssignmentQuery = new() { PageRequest = pageRequest };
        ClassTeachingAssignmentListModel result = await Mediator.Send(getListClassTeachingAssignmentQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdClassTeachingAssignmentQuery getClassTeachingAssignmentQuery = new() { Id = id };
        ClassTeachingAssignmentGetByIdDto getClassTeachingAssignmentResult = await Mediator.Send(getClassTeachingAssignmentQuery);
        return Ok(getClassTeachingAssignmentResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateClassTeachingAssignmentCommand createdClassTeachingAssignment)
    {
        CreatedClassTeachingAssignmentDto result = await Mediator.Send(createdClassTeachingAssignment);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateClassTeachingAssignmentCommand updateClassTeachingAssignment)
    {
        UpdatedClassTeachingAssignmentDto result = await Mediator.Send(updateClassTeachingAssignment);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteClassTeachingAssignmentCommand deleteClassTeachingAssignmentCommand = new() { Id = id };
        await Mediator.Send(deleteClassTeachingAssignmentCommand);
        return NoContent();
    }
}
