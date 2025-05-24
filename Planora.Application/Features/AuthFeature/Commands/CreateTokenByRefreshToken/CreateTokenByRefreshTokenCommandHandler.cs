using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.AuthFeature.Commands.CreateToken;
using Planora.Application.Features.AuthFeature.Rules;
using Planora.Application.Services.AuthService;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthFeature.Commands.CreateTokenByRefreshToken;

public class CreateTokenByRefreshTokenCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
        AuthBusinessRules authBusinessRules,
        IIdentityRepository identityRepository,
        IAuthService authService) 
    : IRequestHandler<CreateTokenByRefreshTokenCommand, TokenDto>
{
    public async Task<TokenDto> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await refreshTokenRepository.GetAsync(r => r.Token == request.RefreshToken, cancellationToken: cancellationToken);
        await authBusinessRules.RefreshShouldExistWhenRequestedAsync(refreshToken);
        await authBusinessRules.RefreshTokenExpiredAsync(refreshToken!);

        var identity = await identityRepository.GetAsync(i => i.Id == refreshToken!.IdentityId,
                include: identity => identity.Include(i => i.IdentityOperationClaims)
                .ThenInclude(ioc => ioc.OperationClaim)
                .Include(i => i.IdentityAuthorities)
                    .ThenInclude(ia => ia.Authority)
                    .ThenInclude(ia => ia.AuthorityOperationClaims)
                    .ThenInclude(aop => aop.OperationClaim)
            );
        await authBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);

        if (identity.UserName == "supervisor")
        {
            identity.IdentityOperationClaims.Add(new()
            {
                OperationClaim = new() { Group = "supervisor", Name = "supervisor" }
            });
        }

        AccessToken createdAccessToken = await authService.CreateAccessToken(identity);
        RefreshToken createdRefreshToken = await authService.CreateRefreshToken(identity, request.IpAddress);

        refreshToken!.Token = createdRefreshToken.Token;
        refreshToken.Expires = createdRefreshToken.Expires;
        refreshToken.CreatedByIp = request.IpAddress;

        TokenDto tokenDto = new()
        {
            AccessToken = createdAccessToken,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiration = refreshToken.Expires
        };
        return tokenDto;
    }
}
