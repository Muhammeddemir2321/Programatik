using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.DeleteLessonScheduleGroup;

public class SoftDeleteLessonScheduleGroupCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.SoftDelete };
}
