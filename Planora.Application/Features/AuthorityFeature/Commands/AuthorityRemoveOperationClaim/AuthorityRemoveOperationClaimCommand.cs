using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;

namespace Planora.Application.Features.AuthorityFeature.Commands.AuthorityRemoveOperationClaim;

public record AuthorityRemoveOperationClaimCommand : IRequest<bool>, ISecuredRequest
{
    public Guid AuthorityId { get; set; }
    public Guid OperationClaimId { get; set; }
    public string[] Roles => new string[] { AuthorityClaimConstants.UpdateClaims };
}