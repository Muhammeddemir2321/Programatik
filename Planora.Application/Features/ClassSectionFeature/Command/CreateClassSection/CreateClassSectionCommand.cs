using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;

public class CreateClassSectionCommand : IRequest<CreatedClassSectionDto>, ISecuredRequest
{
    public string Name { get; set; }
    public Guid GradeId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.Create };
}
