using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.DeleteLessonScheduleGroup;

public class HardDeleteLessonScheduleGroupCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public DeleteLessonSchedulesByGroupIdCommand DeleteLessonSchedulesByGroupIdCommand { get; set; }
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.HardDelete };
}