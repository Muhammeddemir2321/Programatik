using MediatR;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Commands.DeleteOperationClaim;

public class DeleteByIdOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    OperationClaimBusinessRules operationClaimBusinessRules)
    : IRequestHandler<DeleteOperationClaimCommand, bool>
{
    public async Task<bool> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var operationClaim = await planoraUnitOfWork.OperationClaims.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
        await operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);
        await planoraUnitOfWork.OperationClaims.DeleteAsync(operationClaim!, cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
