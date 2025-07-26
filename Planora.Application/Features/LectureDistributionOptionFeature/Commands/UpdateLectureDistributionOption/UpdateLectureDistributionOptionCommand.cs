using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.UpdateLectureDistributionOption;

public class UpdateLectureDistributionOptionCommand : IRequest<UpdatedLectureDistributionOptionDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int TotalHours { get; set; }
    public List<int> Distribution { get; set; } = [];
    [JsonIgnore]
    public string[] Roles => new string[] { LectureDistributionOptionClaimConstant.Update };
}
