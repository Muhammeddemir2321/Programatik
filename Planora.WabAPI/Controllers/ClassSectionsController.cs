using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;
using Planora.Application.Features.ClassSectionFeature.Command.DeleteClassSection;
using Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;
using Planora.Application.Features.ClassSectionFeature.Models;
using Planora.Application.Features.ClassSectionFeature.Queries.GetByIdClassSection;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSectionByDynamic;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassSectionsController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllClassSectionByDynamicQuery getListClassSectionQuery = new() { PageRequest = pageRequest, Query = query };
        ClassSectionListModel result = await Mediator.Send(getListClassSectionQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllClassSectionQuery getListClassSectionQuery = new() { PageRequest = pageRequest };
        ClassSectionListModel result = await Mediator.Send(getListClassSectionQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdClassSectionQuery getClassSectionQuery = new() { Id = id };
        ClassSectionGetByIdDto getClassSectionResult = await Mediator.Send(getClassSectionQuery);
        return Ok(getClassSectionResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateClassSectionCommand createdClassSection)
    {
        CreatedClassSectionDto result = await Mediator.Send(createdClassSection);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateClassSectionCommand updateClassSection)
    {
        UpdatedClassSectionDto result = await Mediator.Send(updateClassSection);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteClassSectionCommand deleteClassSectionCommand = new() { Id = id };
        await Mediator.Send(deleteClassSectionCommand);
        return NoContent();
    }
}
