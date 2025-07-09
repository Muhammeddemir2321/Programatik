using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;

public class CreateLessonScheduleCommand : IRequest<CreatedLessonScheduleGroupDto>, ISecuredRequest
{
    [JsonIgnore]
    public Guid LessonScheduleGroupId { get; set; }
    public List<string> SelectedConstraintNames { get; set; } = new();
    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleClaimConstants.Create };
}
