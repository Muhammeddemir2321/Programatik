using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.AuthorityFeature.Commands.AuthorityRemoveOperationClaim;
using Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaim;
using Planora.Application.Features.AuthorityFeature.Commands.AuthoritySetOperationClaimList;
using Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;
using Planora.Application.Features.AuthorityFeature.Commands.DeleteAuthority;
using Planora.Application.Features.AuthorityFeature.Commands.UpdateAuthority;
using Planora.Application.Features.AuthorityFeature.Models;
using Planora.Application.Features.AuthorityFeature.Queries.GetByIdAuthority;
using Planora.Application.Features.AuthorityFeature.Queries.GetOperationClaimListByAuthorityId;
using Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;
using Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthorityByDynamic;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthoritiesController : BaseController
{
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
    {
        ListAllAuthorityByDynamicQuery getListAuthorityQuery = new() { PageRequest = pageRequest, Query = query };
        AuthorityListModel result = await Mediator.Send(getListAuthorityQuery);
        return Ok(result);
    }
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllAuthorityQuery getListAuthorityQuery = new() { PageRequest = pageRequest };
        AuthorityListModel result = await Mediator.Send(getListAuthorityQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdAuthorityQuery getAuthorityQuery = new() { Id = id };
        AuthorityGetByIdDto getAuthorityResult = await Mediator.Send(getAuthorityQuery);
        return Ok(getAuthorityResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateAuthorityCommand createdAuthority)
    {
        CreatedAuthorityDto result = await Mediator.Send(createdAuthority);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorityCommand updateAuthority)
    {
        UpdatedAuthorityDto result = await Mediator.Send(updateAuthority);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteAuthorityCommand deleteByIdAuthorityCommand = new() { Id = id };
        await Mediator.Send(deleteByIdAuthorityCommand);
        return NoContent();
    }
    [HttpPost("AddOperationClaim")]
    public async Task<IActionResult> AddOperationClaim([FromBody] AuthoritySetOperationClaimCommand authoritySetOperationClaimCommand)
    {
        bool result = await Mediator.Send(authoritySetOperationClaimCommand);
        return Ok(result);
    }
    [HttpPost("RemoveOperationClaim")]
    public async Task<IActionResult> RemoveOperationClaim([FromBody] AuthorityRemoveOperationClaimCommand authorityRemoveOperationClaimCommand)
    {
        bool result = await Mediator.Send(authorityRemoveOperationClaimCommand);
        return Ok(result);
    }
    [HttpPost("SetOperationClaimList")]
    public async Task<IActionResult> SetOperationClaimList([FromBody] AuthoritySetOperationClaimListCommand authoritySetOperationClaimListCommand)
    {
        bool result = await Mediator.Send(authoritySetOperationClaimListCommand);
        return Ok(result);
    }
    [HttpGet("GetOperationClaimListByAuthorityId")]
    public async Task<IActionResult> GetOperationClaimListByAuthorityId([FromQuery] GetOperationClaimListByAuthorityIdQuery getOperationClaimListByCustomerIdQuery)
    {
        var result = await Mediator.Send(getOperationClaimListByCustomerIdQuery);
        return Ok(result);
    }
}