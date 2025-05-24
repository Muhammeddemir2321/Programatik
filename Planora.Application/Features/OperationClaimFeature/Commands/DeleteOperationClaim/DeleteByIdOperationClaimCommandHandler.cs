using MediatR;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Commands.DeleteOperationClaim;

public class DeleteByIdOperationClaimCommandHandler(
    IOperationClaimRepository operationClaimRepository,
    OperationClaimBusinessRules operationClaimBusinessRules)
    : IRequestHandler<DeleteOperationClaimCommand, bool>
{
    public async Task<bool> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var operationClaim = await operationClaimRepository.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
        await operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);
        await operationClaimRepository.DeleteAsync(operationClaim, cancellationToken);
        return true;
    }
}
