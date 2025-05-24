using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Queries.GetByIdAuthority
{
    public class GetByIdAuthorityQuery : IRequest<AuthorityGetByIdDto>, ISecuredRequest
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public string[] Roles => [AuthorityClaimConstants.Get];
    }
}
