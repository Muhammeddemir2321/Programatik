using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;

public class CreateTeacherUnavailableCommand : IRequest<CreatedTeacherUnavailableDto>, ISecuredRequest
{
    public int TeacherFakeId { get; set; }
    public Guid TeacherId { get; set; }
    public int DayOfWeek { get; set; }
    public int? StartHour { get; set; }
    public int? EndHour { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.Create };
}
