using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassSectionFeature.Command.DeleteClassSection;

public class DeleteClassSectionCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassSectionClaimConstants.Delete };
}
