using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IIdentityOperationClaimRepository _identityOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IIdentityAuthorityRepository _identityAuthorityRepository;

    public AuthManager(IIdentityOperationClaimRepository identityOperationClaimRepository,
        ITokenHelper tokenHelper,
        IRefreshTokenRepository refreshTokenRepository,
        IIdentityAuthorityRepository identityAuthorityRepository)
    {
        _identityOperationClaimRepository = identityOperationClaimRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
        _identityAuthorityRepository = identityAuthorityRepository;
    }
    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
    public async Task<AccessToken> CreateAccessToken(IdentityJwt identityJwt)
    {
        IList<IdentityAuthority> identityAuthorities = await _identityAuthorityRepository.GetAllAsync(a => a.IdentityId == identityJwt.Identity.Id, include: u =>
                                                                u.Include(u => u.Authority)
        );
        IList<IdentityOperationClaim> identityOperationClaims =
           await _identityOperationClaimRepository.GetAllAsync(u => u.IdentityId == identityJwt.Identity.Id,
                                                            include: u =>
                                                                u.Include(u => u.OperationClaim)
           );
        IList<Authority> authorities =
            identityAuthorities.Select(u => u.Authority).ToList();
        IList<OperationClaim> operationClaims =
            identityOperationClaims.Select(u => u.OperationClaim).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(identityJwt);
        return accessToken;
    }

    public async Task<RefreshToken> CreateRefreshToken(IdentityJwt identityJwt, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(identityJwt, ipAddress);
        return await Task.FromResult(refreshToken);
    }
}
