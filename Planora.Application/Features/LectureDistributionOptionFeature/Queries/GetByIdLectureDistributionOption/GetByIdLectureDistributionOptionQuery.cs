using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.GetByIdLectureDistributionOption;

public class GetByIdLectureDistributionOptionQuery : IRequest<LectureDistributionOptionGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureDistributionOptionClaimConstant.Get };
}
