using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.GetByIdLessonSchedule;

public class GetByIdLessonScheduleQuery : IRequest<LessonScheduleGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new string[] { LessonScheduleClaimConstants.Get };
}
