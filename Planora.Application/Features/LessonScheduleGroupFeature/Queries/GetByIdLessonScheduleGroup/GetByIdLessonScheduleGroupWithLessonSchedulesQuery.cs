using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class GetByIdLessonScheduleGroupWithLessonSchedulesQuery : IRequest<LessonScheduleGroupWithLessonSchedulesGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Get };
}
