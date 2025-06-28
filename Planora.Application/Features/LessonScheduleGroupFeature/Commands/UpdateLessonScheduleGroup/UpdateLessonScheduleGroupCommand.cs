using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupCommand : IRequest<UpdatedLessonScheduleGroupDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Update };
}
