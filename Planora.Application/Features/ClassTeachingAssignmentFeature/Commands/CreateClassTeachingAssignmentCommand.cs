using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class CreateClassTeachingAssignmentCommand : IRequest<CreatedClassTeachingAssignmentDto>, ISecuredRequest
{
    public int WeeklyHourCount { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    public int LectureFakeId { get; set; }
    public int TeacherFakeId { get; set; }
    public int ClassSectionFakeId { get; set; }
    public bool IsOptional { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Create };
}