using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.IdentityFeature.Commands;
using Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;
using Planora.Application.Features.IdentityFeature.Commands.CreateSupervisor;
using Planora.Application.Features.IdentityFeature.Commands.HardDeleteIdentity;
using Planora.Application.Features.IdentityFeature.Commands.SoftDeleteIdentity;
using Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Features.IdentityFeature.Queries.GetByIdIdentity;
using Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityByDynamic;
using Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityQuery;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentitiesController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllIdentityByDynamicQuery getListBaseUserQuery = new() { PageRequest = pageRequest, Query = query };
        IdentityListModel result = await Mediator.Send(getListBaseUserQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllIdentityQuery getListBaseUserQuery = new() { PageRequest = pageRequest };
        IdentityListModel result = await Mediator.Send(getListBaseUserQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdIdentityQuery getBaseUserQuery = new() { Id = id };
        IdentityGetByIdDto result = await Mediator.Send(getBaseUserQuery);
        return Ok(result);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateIdentityCommand createdBaseUser)
    {
        CreatedIdentityDto result = await Mediator.Send(createdBaseUser);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateIdentityCommand updateBaseUser)
    {
        UpdatedIdentityDto result = await Mediator.Send(updateBaseUser);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        HardDeleteIdentityCommand deleteBaseUserCommand = new() { Id = id };
        await Mediator.Send(deleteBaseUserCommand);
        return NoContent();
    }
    [HttpGet("SoftDeleteById/{id}")]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
        SoftDeleteIdentityCommand softDeleteBaseUserCommand = new() { Id = id };
        await Mediator.Send(softDeleteBaseUserCommand);
        return NoContent();
    }
    [HttpPost("Setup")]
    public async Task<IActionResult> Setup()
    {
        var command = new CreateSupervisorCommand();
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
