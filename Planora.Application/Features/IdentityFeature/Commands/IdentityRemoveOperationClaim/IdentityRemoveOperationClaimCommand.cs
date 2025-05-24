using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;

namespace Planora.Application.Features.IdentityFeature.Commands;

public record IdentityRemoveOperationClaimCommand : IRequest<bool>, ISecuredRequest
{
    public Guid IdentityId { get; set; }
    public Guid OperationClaimId { get; set; }
    public string[] Roles => new string[] { IdentityClaimConstants.UpdateOperationClaim };
}