using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Constants;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;

public class DeleteLessonSchedulesByGroupIdCommand : IRequest<bool>, ISecuredRequest
{
    public Guid LessonScheduleGroupId { get; set; }
    public string[] Roles => new string[] { LessonScheduleClaimConstants.Delete };
}
