using MediatR;
using Planora.Application.Features.AuthFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthFeature.Commands.RevokeRefreshToken;

public class RevokeRefreshTokenCommandHandler (
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthBusinessRules authBusinessRules)
    : IRequestHandler<RevokeRefreshTokenCommand, bool>
{
    public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await planoraUnitOfWork.RefreshTokens.GetAsync(r => r.Token == request.RefreshToken, cancellationToken: cancellationToken);
        await authBusinessRules.RefreshShouldExistWhenRequestedAsync(refreshToken);
        await planoraUnitOfWork.RefreshTokens.DeleteAsync(refreshToken!, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
