using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.DeleteTeacherUnavailable;

public class DeleteTeacherUnavailableCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.Delete };
}
