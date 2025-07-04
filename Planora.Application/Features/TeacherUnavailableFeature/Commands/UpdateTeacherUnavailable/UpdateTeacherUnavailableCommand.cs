using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;

public class UpdateTeacherUnavailableCommand : IRequest<UpdatedTeacherUnavailableDto>, ISecuredRequest
{

    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.Update };
}
