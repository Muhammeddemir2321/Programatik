using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;

public class ListAllTeacherUnavailableQuery : IRequest<TeacherUnavailableListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.List };
}
