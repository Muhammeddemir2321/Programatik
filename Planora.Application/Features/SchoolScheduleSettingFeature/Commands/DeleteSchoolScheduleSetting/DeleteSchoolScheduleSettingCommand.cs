using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Constants;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Commands.DeleteSchoolScheduleSetting;

public class DeleteSchoolScheduleSettingCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolScheduleSettingClaimConstants.Delete };
}
