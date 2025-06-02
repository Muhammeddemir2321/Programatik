using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Queries.GetByIdClassSection;

public class GetByIdClassSectionQuery : IRequest<ClassSectionGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.Get };
}
