using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.AuthFeature.Rules;
using Planora.Application.Services.AuthService;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthFeature.Commands.CreateToken;

public class CreateTokenCommandHandler(
    AuthBusinessRules authBusinessRules,
    IIdentityRepository identityRepository,
    IAuthService authService,
    IRefreshTokenRepository refreshTokenRepository)
    : IRequestHandler<CreateTokenCommand, TokenDto>
{
    public async Task<TokenDto> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(i => i.UserName == request.UserName,
                include: identity => identity.Include(i => i.IdentityOperationClaims)
                .ThenInclude(ioc => ioc.OperationClaim)
                    .Include(i => i.IdentityAuthorities)
                    .ThenInclude(ia => ia.Authority)
                    .ThenInclude(ia => ia.AuthorityOperationClaims)
                    .ThenInclude(aop => aop.OperationClaim)
                , cancellationToken: cancellationToken);
        await authBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        if (!await identityRepository.CheckPasswordAsync(identity, request.Password))
            authBusinessRules.PasswordIsWrongAsync();
        if (identity.UserName == "supervisor")
        {
            identity.IdentityOperationClaims.Add(new()
            {
                OperationClaim = new() { Group = "supervisor", Name = "supervisor" }
            });
        }

        var refreshTokens = await refreshTokenRepository.GetAllAsync(r => r.IdentityId == identity.Id, cancellationToken: cancellationToken);

        foreach (var token in refreshTokens)
        {
            await refreshTokenRepository.DeleteAsync(token, cancellationToken: cancellationToken);
        }
        AccessToken createdAccessToken = await authService.CreateAccessToken(identity);
        RefreshToken createdRefreshToken = await authService.CreateRefreshToken(identity, request.IpAddress);
        RefreshToken addedRefreshToken = await authService.AddRefreshToken(createdRefreshToken);

        TokenDto tokenDto = new()
        {
            AccessToken = createdAccessToken,
            RefreshToken = addedRefreshToken.Token,
            RefreshTokenExpiration = addedRefreshToken.Expires
        };
        return tokenDto;
    }
}
