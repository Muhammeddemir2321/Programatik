using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries.GetByIdIdentity;

public class GetByIdIdentityQuery : IRequest<IdentityGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Get };
}
