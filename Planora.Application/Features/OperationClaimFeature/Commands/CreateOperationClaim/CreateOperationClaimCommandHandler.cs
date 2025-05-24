using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.OperationClaimFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandHandler(
    IOperationClaimRepository operationClaimRepository,
    IMapper mapper,
    OperationClaimBusinessRules operationClaimBusinessRules)
    : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
{
    public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await operationClaimBusinessRules.NameMustBeUniqueWhenCreateAsync(request.Name);
        var mappedOperationClaim = mapper.Map<OperationClaim>(request);
        var createdOperationClaim = await operationClaimRepository.AddAsync(mappedOperationClaim, cancellationToken);
        return mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
    }
}
