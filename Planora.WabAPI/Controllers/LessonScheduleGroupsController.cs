using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.DeleteLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonScheduleGroupsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ListAllLessonScheduleGroupQuery getListLessonScheduleGroupQuery = new();
            List<LessonScheduleGroupListDto> result = await Mediator.Send(getListLessonScheduleGroupQuery);
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdLessonScheduleGroupWithLessonSchedulesQuery getLessonScheduleGroupQuery = new() { Id = id };
            LessonScheduleGroupWithLessonSchedulesGetByIdDto result = await Mediator.Send(getLessonScheduleGroupQuery);
            return Ok(result);
        }
        [HttpGet("GetListLessonScheduleGetByGroupId/{id}")]
        public async Task<IActionResult> GetListLessonScheduleGetByGroupId(Guid id)
        {
            ListAllLessonScheduleGetByGroupIdQuery getListLessonScheduleGetByGroupIdQuery = new() { LessonScheduleGroupId = id };
            List<ListAllLessonScheduleGetByGroupIdDto> result = await Mediator.Send(getListLessonScheduleGetByGroupIdQuery);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateLessonScheduleGroupCommand createdLessonScheduleGroupCommand)
        {
            CreatedLessonScheduleGroupDto result = await Mediator.Send(createdLessonScheduleGroupCommand);
            return Created("", result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLessonScheduleGroupCommand updateLessonScheduleGroupCommand)
        {
            UpdatedLessonScheduleGroupDto result = await Mediator.Send(updateLessonScheduleGroupCommand);
            return Created("", result);
        }
        [HttpPost("UpdateIsActive")]
        public async Task<IActionResult> UpdateIsActive([FromBody] UpdateLessonScheduleGroupIsActiveCommand updateLessonScheduleGroupIsActiveCommand)
        {
            List<UpdatedLessonScheduleGroupDto> result = await Mediator.Send(updateLessonScheduleGroupIsActiveCommand);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HardDeleteLessonScheduleGroupCommand hardDeleteLessonScheduleGroupCommand = new() { Id = id };
            await Mediator.Send(hardDeleteLessonScheduleGroupCommand);
            return NoContent();
        }
    }
}
