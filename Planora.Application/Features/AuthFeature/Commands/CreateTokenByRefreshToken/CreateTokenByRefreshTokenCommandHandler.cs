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
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthBusinessRules authBusinessRules,
    IAuthService authService) 
    : IRequestHandler<CreateTokenByRefreshTokenCommand, TokenDto>
{
    public async Task<TokenDto> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await planoraUnitOfWork.RefreshTokens.GetAsync(r => r.Token == request.RefreshToken, cancellationToken: cancellationToken);
        await authBusinessRules.RefreshShouldExistWhenRequestedAsync(refreshToken);
        await authBusinessRules.RefreshTokenExpiredAsync(refreshToken!);

        var identity = await planoraUnitOfWork.Identities.GetAsync(i => i.Id == refreshToken!.IdentityId,
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
        var user = await planoraUnitOfWork.Users.GetAsync(i => i.IdentityId == identity.Id, cancellationToken: cancellationToken);
        IdentityJwt identityJwt = new()
        {
            Identity = identity,
            SchoolId = user?.SchoolId ?? Guid.Empty
        };
        AccessToken createdAccessToken = await authService.CreateAccessToken(identityJwt);
        RefreshToken createdRefreshToken = await authService.CreateRefreshToken(identityJwt, request.IpAddress);

        refreshToken!.Token = createdRefreshToken.Token;
        refreshToken.Expires = createdRefreshToken.Expires;
        refreshToken.CreatedByIp = request.IpAddress;
        await planoraUnitOfWork.CommitAsync();
        TokenDto tokenDto = new()
        {
            AccessToken = createdAccessToken,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiration = refreshToken.Expires
        };
        return tokenDto;
    }
}
