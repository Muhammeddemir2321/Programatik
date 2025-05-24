using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Commands.DeleteOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Commands.UpdateOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Models;
using Planora.Application.Features.OperationClaimFeature.Queries.GetByIdOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaimByDynamic;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllOperationClaimByDynamicQuery getListOperationClaimQuery = new() { PageRequest = pageRequest, Query = query };
        var result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdOperationClaimQuery getOperationClaimQuery = new() { Id = id };
        OperationClaimGetByIdDto getOperationClaimResult = await Mediator.Send(getOperationClaimQuery);
        return Ok(getOperationClaimResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createdOperationClaim)
    {
        CreatedOperationClaimDto result = await Mediator.Send(createdOperationClaim);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
    {
        UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaim);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteOperationClaimCommand deleteByIdOperationClaimCommand = new() { Id = id };
        await Mediator.Send(deleteByIdOperationClaimCommand);
        return NoContent();
    }
}