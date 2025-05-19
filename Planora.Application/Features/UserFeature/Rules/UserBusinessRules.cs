using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Rules;

public class UserBusinessRules(IUserRepository userRepository)
{
    public async Task UserShouldExistWhenRequestedAsync(User? user)
    {
        if (user is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
