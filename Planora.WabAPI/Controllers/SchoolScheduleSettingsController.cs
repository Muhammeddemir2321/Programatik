using Core.Application.Requests;
using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.SchoolScheduleSettingFeature.Command.CreateSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Command.DeleteSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Command.UpdateSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Models;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.ListAllSchoolScheduleSetting;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolScheduleSettingsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllSchoolScheduleSettingQuery getListSchoolScheduleSettingQuery = new() { PageRequest = pageRequest };
        SchoolScheduleSettingListModel result = await Mediator.Send(getListSchoolScheduleSettingQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdSchoolScheduleSettingQuery getSchoolScheduleSettingQuery = new() { Id = id };
        SchoolScheduleSettingGetByIdDto getSchoolScheduleSettingResult = await Mediator.Send(getSchoolScheduleSettingQuery);
        return Ok(getSchoolScheduleSettingResult);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateSchoolScheduleSettingCommand createdSchoolScheduleSetting)
    {
        CreatedSchoolScheduleSettingDto result = await Mediator.Send(createdSchoolScheduleSetting);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSchoolScheduleSettingCommand updateSchoolScheduleSetting)
    {
        UpdatedSchoolScheduleSettingDto result = await Mediator.Send(updateSchoolScheduleSetting);
        return Created("", result);
    }
    [HttpGet("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        DeleteSchoolScheduleSettingCommand deleteSchoolScheduleSettingCommand = new() { Id = id };
        await Mediator.Send(deleteSchoolScheduleSettingCommand);
        return NoContent();
    }
}
