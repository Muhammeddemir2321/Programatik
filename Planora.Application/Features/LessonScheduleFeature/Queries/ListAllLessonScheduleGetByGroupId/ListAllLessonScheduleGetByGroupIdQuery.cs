using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;

public class ListAllLessonScheduleGetByGroupIdQuery : IRequest<List<ListAllLessonScheduleGetByGroupIdDto>>, ISecuredRequest
{
    public Guid LessonScheduleGroupId { get; set; }
    public string[] Roles => new string[] { LessonScheduleClaimConstants.List };
}
