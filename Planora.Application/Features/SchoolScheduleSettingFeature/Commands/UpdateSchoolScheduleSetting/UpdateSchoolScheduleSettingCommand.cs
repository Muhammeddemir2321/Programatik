using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Commands.UpdateSchoolScheduleSetting;

public class UpdateSchoolScheduleSettingCommand : IRequest<UpdatedSchoolScheduleSettingDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public TimeSpan FirstLessonStartTime { get; set; }
    public int LessonDurationMinutes { get; set; }
    public int BreakDurationMinutes { get; set; }
    public int WeeklyLessonDayCount { get; set; }
    public int DailyLessonCount { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolScheduleSettingClaimConstants.Update };
}
