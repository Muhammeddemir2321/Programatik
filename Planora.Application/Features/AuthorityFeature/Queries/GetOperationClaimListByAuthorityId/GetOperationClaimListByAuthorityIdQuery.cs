using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Newtonsoft.Json;
using Planora.Application.Features.AuthorityFeature.Constants;

namespace Planora.Application.Features.AuthorityFeature.Queries.GetOperationClaimListByAuthorityId;

public record GetOperationClaimListByAuthorityIdQuery : IRequest<IList<OperationClaim>>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.GetClaimsById };
}