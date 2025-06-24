using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonSchedule;

public class ListAllLessonScheduleQuery:IRequest<LessonScheduleListDto>, ISecuredRequest
{
    public string[] Roles => new string[] { LessonScheduleClaimConstants.List };
}
