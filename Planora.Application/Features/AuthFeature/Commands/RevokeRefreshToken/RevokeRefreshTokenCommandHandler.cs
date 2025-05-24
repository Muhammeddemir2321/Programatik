using MediatR;
using Planora.Application.Features.AuthFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthFeature.Commands.RevokeRefreshToken;

public class RevokeRefreshTokenCommandHandler (
    IRefreshTokenRepository refreshTokenRepository,
    AuthBusinessRules authBusinessRules)
    : IRequestHandler<RevokeRefreshTokenCommand, bool>
{
    public async Task<bool> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await refreshTokenRepository.GetAsync(r => r.Token == request.RefreshToken, cancellationToken: cancellationToken);
        await authBusinessRules.RefreshShouldExistWhenRequestedAsync(refreshToken);
        await refreshTokenRepository.DeleteAsync(refreshToken!, cancellationToken: cancellationToken);
        return true;
    }
}
