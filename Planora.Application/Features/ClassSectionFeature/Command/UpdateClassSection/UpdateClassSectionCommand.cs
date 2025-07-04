using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;

public class UpdateClassSectionCommand : IRequest<UpdatedClassSectionDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid GradeId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.Update };
}
