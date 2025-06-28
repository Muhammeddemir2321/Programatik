using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;

public class CreateLessonScheduleGroupCommand : IRequest<CreatedLessonScheduleGroupDto>, ISecuredRequest
{
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public CreateLessonScheduleCommand createLessonScheduleCommand { get; set; }

    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Create };
}
