using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupCommand : IRequest<UpdatedLessonScheduleGroupDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Update };
}
