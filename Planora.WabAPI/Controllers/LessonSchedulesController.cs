using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonSchedulesController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            LessonScheduleListDto result = await Mediator.Send(new ListAllLessonScheduleQuery { });
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ListAllLessonScheduleGetByGroupIdQuery getListLessonScheduleGetByGroupIdQuery = new() { LessonScheduleGroupId = id };
            List<ListAllLessonScheduleGetByGroupIdDto> result = await Mediator.Send(getListLessonScheduleGetByGroupIdQuery);
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateLessonScheduleCommand createdLessonSchedulee)
        {
            List<CreatedLessonScheduleDto> result = await Mediator.Send(createdLessonSchedulee);
            return Created("", result);
        }
        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteLessonSchedulesByGroupIdCommand deleteLessonScheduleCommand = new() { LessonScheduleGroupId = id };
            await Mediator.Send(deleteLessonScheduleCommand);
            return NoContent();
        }
    }
}
