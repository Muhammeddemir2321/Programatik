using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;

public class GetByIdSchoolScheduleSettingQuery : IRequest<SchoolScheduleSettingGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolScheduleSettingClaimConstants.Get };
}
