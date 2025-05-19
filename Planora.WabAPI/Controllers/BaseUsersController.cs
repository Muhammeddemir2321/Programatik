using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.BaseUserFeature.Commad;
using Planora.Application.Features.BaseUserFeature.Dtos;
using Planora.Application.Features.BaseUserFeature.Models;
using Planora.Application.Features.BaseUserFeature.Queries;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseUsersController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllBaseUserByDynamicQuery getListBaseUserQuery = new() { PageRequest = pageRequest, Query = query };
            BaseUserListModel result = await Mediator.Send(getListBaseUserQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllBaseUserQuery getListBaseUserQuery = new() { PageRequest = pageRequest };
            BaseUserListModel result = await Mediator.Send(getListBaseUserQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdBaseUserQuery getBaseUserQuery = new() { Id = id };
            BaseUserGetByIdDto result = await Mediator.Send(getBaseUserQuery);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBaseUserCommand createdBaseUser)
        {
            CreatedBaseUserDto result = await Mediator.Send(createdBaseUser);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBaseUserCommand updateBaseUser)
        {
            UpdatedBaseUserDto result = await Mediator.Send(updateBaseUser);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HardDeleteBaseUserCommand deleteBaseUserCommand = new() { Id = id };
            await Mediator.Send(deleteBaseUserCommand);
            return NoContent();
        }
        [HttpGet("SoftDeleteById/{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            SoftDeleteBaseUserCommand softDeleteBaseUserCommand = new() { Id = id };
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
}
