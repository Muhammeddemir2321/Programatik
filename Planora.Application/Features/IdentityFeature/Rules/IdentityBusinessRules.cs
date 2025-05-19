using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Rules;

public class IdentityBusinessRules(IIdentityRepository identityRepository)
{
    public async Task IdentityShouldExistWhenRequestedAsync(Identity identity)
    {
        if (identity is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task UserNameMustBeUniqeWhenCreateAsync(string userName)
    {
        var identity = await identityRepository.GetAsync(c => c.UserName == userName);
        if (identity != null)
            throw new BusinessException("UserName already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("UserName", userName ?? string.Empty);
    }
    public async Task UserNameMustBeUniqueWhenUpdateAsync(Guid id, string userName)
    {
        var identity = await identityRepository.GetAsync(c => c.Id != id && c.UserName == userName);
        if (identity != null) throw new BusinessException("Username already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("UserName", userName ?? string.Empty);
    }
}
