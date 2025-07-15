using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;

public class GetByTeacherIdTeacherUnavailableQuery:IRequest<List<TeacherUnavailableListDto>>,ISecuredRequest
{
    public Guid TeacherId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.Get };
}
