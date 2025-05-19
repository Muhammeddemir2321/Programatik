using Core.Application.Requests;
using Core.Persistence.Controllers;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.UserFeature.Command.CreateUser;
using Planora.Application.Features.UserFeature.Command.DeleteUser;
using Planora.Application.Features.UserFeature.Command.UpdateUser;
using Planora.Application.Features.UserFeature.Models;
using Planora.Application.Features.UserFeature.Queries.GetByIdUser;
using Planora.Application.Features.UserFeature.Queries.ListAllUser;
using Planora.Application.Features.UserFeature.Queries.ListAllUserByDynamic;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest, [FromBody] Dynamic query = null)
        {
            ListAllUserByDynamicQuery getListUserQuery = new() { PageRequest = pageRequest, Query = query };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListAllUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdUserQuery getUserQuery = new() { Id = id };
            UserGetByIdDto getUserResult = await Mediator.Send(getUserQuery);
            return Ok(getUserResult);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createdUser)
        {
            CreatedUserDto result = await Mediator.Send(createdUser);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUser)
        {
            UpdatedUserDto result = await Mediator.Send(updateUser);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HardDeleteUserCommand deleteUserCommand = new() { Id = id };
            await Mediator.Send(deleteUserCommand);
            return NoContent();
        }
        [HttpGet("SoftDeleteById/{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            SoftDeleteUserCommand softDeleteUserCommand = new() { Id = id };
            await Mediator.Send(softDeleteUserCommand);
            return NoContent();
        }
    }
}
