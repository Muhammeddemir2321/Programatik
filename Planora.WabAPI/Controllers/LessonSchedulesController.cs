using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Queries.GetByIdLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonSchedule;

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
            GetByIdLessonScheduleQuery getLessonScheduleQuery = new() { Id = id };
            LessonScheduleGetByIdDto getLessonScheduleResult = await Mediator.Send(getLessonScheduleQuery);
            return Ok(getLessonScheduleResult);
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
            DeleteLessonSchedulesByGroupIdCommand deleteLessonScheduleCommand = new() { Id = id };
            await Mediator.Send(deleteLessonScheduleCommand);
            return NoContent();
        }
    }
}
