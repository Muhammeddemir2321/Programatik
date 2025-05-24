using AutoMapper;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Queries.GetByIdOperationClaim;

public class GetByIdOperationClaimQueryHandler(
    IOperationClaimRepository operationClaimRepository,
    IMapper mapper,
    OperationClaimBusinessRules operationClaimBusinessRules)
    : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimGetByIdDto>
{
    public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
    {
        var operationClaim = await operationClaimRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

        await operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);

        return mapper.Map<OperationClaimGetByIdDto>(operationClaim);
    }
}
