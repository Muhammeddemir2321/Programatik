using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Planora.Application.Features.AuthFeature.Rules;

public class AuthBusinessRules
{
    public async Task IdentityShouldExistWhenRequestedAsync(Identity identity)
    {
        if (identity is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task RefreshShouldExistWhenRequestedAsync(RefreshToken? refreshToken)
    {
        if (refreshToken is null)
            throw new BusinessException("Refresh token is not found", ErrorConstants.RequestedRecordDoesNotExist);
        await Task.CompletedTask;
    }
    public async Task RefreshTokenExpiredAsync(RefreshToken refreshToken)
    {
        if (DateTime.Now > refreshToken.Expires)
            throw new BusinessException("Refresh token is expired", ErrorConstants.RefreshTokenIsExpired);
        await Task.CompletedTask;
    }
    public void PasswordIsWrongAsync()
    {
        throw new BusinessException("Username or password is wrong", ErrorConstants.UsernameOrPasswordIsWrong);
    }
}
