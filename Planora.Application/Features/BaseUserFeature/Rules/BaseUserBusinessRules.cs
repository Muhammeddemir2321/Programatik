using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.BaseUserFeature.Rules;

public class BaseUserBusinessRules(IBaseUserRepository baseUserRepository)
{
    public async Task BaseUserShouldExistWhenRequestedAsync(BaseUser user)
    {
        if (user is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task UserNameMustBeUniqeWhenCreateAsync(string userName)
    {
        var user = await baseUserRepository.GetAsync(c => c.UserName == userName);
        if (user != null)
            throw new BusinessException("UserName already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("UserName", userName ?? string.Empty);
    }
    public async Task UserNameMustBeUniqueWhenUpdateAsync(Guid id, string userName)
    {
        var user = await baseUserRepository.GetAsync(c => c.Id != id && c.UserName == userName);
        if (user != null) throw new BusinessException("FullName already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("UserName", userName ?? string.Empty);
    }
}
