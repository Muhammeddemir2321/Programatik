using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Constants;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;

public class GetByIdTeacherUnavailableQuery : IRequest<TeacherUnavailableGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherUnavailableClaimConstant.Get };
}
