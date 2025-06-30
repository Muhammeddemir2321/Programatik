using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;

public class ListAllLessonScheduleGroupQuery : IRequest<LessonScheduleGroupListModel>, ISecuredRequest
{
    [JsonIgnore]
    public string[] Roles => new string[] { LessonScheduleGroupClaimConstants.List };
}
