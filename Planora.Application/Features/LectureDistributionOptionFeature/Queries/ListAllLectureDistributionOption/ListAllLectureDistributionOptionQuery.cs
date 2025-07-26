using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Constants;
using Planora.Application.Features.LectureDistributionOptionFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;

public class ListAllLectureDistributionOptionQuery : IRequest<LectureDistributionOptionListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureDistributionOptionClaimConstant.List };
}
