using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    OperationClaimBusinessRules operationClaimBusinessRules)
    : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
{
    public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var mailDesign = await planoraUnitOfWork.OperationClaims.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
        await operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(mailDesign);
        await operationClaimBusinessRules.NameMustBeUniqueWhenUpdateAsync(request.Id, request.Name);
        var mappedOperationClaim = mapper.Map<OperationClaim>(request);
        var updatedOperationClaim = await planoraUnitOfWork.OperationClaims.UpdateAsync(mappedOperationClaim, cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
    }
}
