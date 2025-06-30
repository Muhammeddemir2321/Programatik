using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup
{
    public class UpdateLessonScheduleGroupIsActiveCommand : IRequest<List<UpdatedLessonScheduleGroupDto>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Update };
    }
}
