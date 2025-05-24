using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
namespace Planora.Application.Features.AuthorityFeature.Rules
{
    public class AuthorityBusinessRules(IAuthorityRepository authorityRepository)
    {
        public async Task AuthorityShouldExistWhenRequestedAsync(Authority? authority)
        {
            if (authority is null) 
                throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);
            await Task.CompletedTask;
        }
        public async Task NameMustBeUniqueWhenCreateAsync(string name)
        {
            var authority = await authorityRepository.GetAsync(i => i.Name == name);
            if (authority != null) 
                throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                    .WithParam("AuthorityName", name ?? string.Empty);
        }
        public async Task NameMustBeUniqueWhenUpdateAsync(Guid id, string name)
        {
            var authority = await authorityRepository.GetAsync(i => i.Name == name && i.Id != id);
            if (authority != null) 
                throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                    .WithParam("AuthorityName", name ?? string.Empty);
        }
    }
}
