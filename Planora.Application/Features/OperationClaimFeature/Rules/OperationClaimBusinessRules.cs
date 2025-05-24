using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
namespace Planora.Application.Features.OperationClaimFeature.Rules
{
    public class OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        public async Task OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
        {
            if (operationClaim is null) throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);
            await Task.CompletedTask;
        }
        public async Task NameMustBeUniqueWhenCreateAsync(string name)
        {
            var operationClaim = await operationClaimRepository.GetAsync(i => i.Name == name);
            if (operationClaim != null) 
                throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                    .WithParam("OperationClaimName", name ?? string.Empty);
        }
        public async Task NameMustBeUniqueWhenUpdateAsync(Guid id, string name)
        {
            var operationClaim = await operationClaimRepository.GetAsync(i => i.Name == name && i.Id != id);
            if (operationClaim != null)
                throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                    .WithParam("OperationClaimName", name ?? string.Empty);
        }
    }
}
