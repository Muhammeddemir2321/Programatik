using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;

public class CreateLessonScheduleCommand : IRequest<List<CreatedLessonScheduleDto>>, ISecuredRequest
{
    public Guid LessonScheduleGroupId { get; set; }
    public List<string> SelectedConstraintNames { get; set; } = new();
    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleClaimConstants.Create };
}
