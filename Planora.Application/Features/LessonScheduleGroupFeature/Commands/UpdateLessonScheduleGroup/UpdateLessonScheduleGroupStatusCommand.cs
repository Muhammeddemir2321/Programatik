using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup
{
    public class UpdateLessonScheduleGroupStatusCommand : IRequest<List<LessonScheduleGroupListDto>>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.Update };
    }
}
