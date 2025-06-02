using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Constants;
using Planora.Application.Features.SchoolScheduleSettingFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Queries.ListAllSchoolScheduleSetting;

public class ListAllSchoolScheduleSettingQuery : IRequest<SchoolScheduleSettingListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolScheduleSettingClaimConstants.List };
}
