using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;

public class CreateLectureDistributionOptionCommand : IRequest<CreatedLectureDistributionOptionDto>, ISecuredRequest
{
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
    [JsonIgnore]
    public string[] Roles => new string[] { LectureDistributionOptionClaimConstant.Create };
}
