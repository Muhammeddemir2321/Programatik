using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.UserFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.UserFeature.Queries.GetByIdUser;

public class GetByIdUserQuery : IRequest<UserGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { UserClaimConstants.Get };
}
