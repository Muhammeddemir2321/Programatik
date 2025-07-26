using Core.Application.Requests;
using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.UpdateLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Models;
using Planora.Application.Features.LectureDistributionOptionFeature.Queries.GetByIdLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;
using Planora.Application.Features.SchoolScheduleSettingFeature.Commands.UpdateSchoolScheduleSetting;

namespace Planora.WabAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LectureDistributionOptionsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        ListAllLectureDistributionOptionQuery getListLectureDistributionOptionQuery = new() { PageRequest = pageRequest };
        LectureDistributionOptionListModel result = await Mediator.Send(getListLectureDistributionOptionQuery);
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        GetByIdLectureDistributionOptionQuery getLectureDistributionOptionQuery = new() { Id = id };
        LectureDistributionOptionGetByIdDto result = await Mediator.Send(getLectureDistributionOptionQuery);
        return Ok(result);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateLectureDistributionOptionCommand createdLectureDistributionOption)
    {
        CreatedLectureDistributionOptionDto result = await Mediator.Send(createdLectureDistributionOption);
        return Created("", result);
    }
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateLectureDistributionOptionCommand updateLectureDistributionOption)
    {
        UpdatedLectureDistributionOptionDto result = await Mediator.Send(updateLectureDistributionOption);
        return Created("", result);
    }
}
