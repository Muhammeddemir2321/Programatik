using Core.Security.Entities;
using Core.Security.JWT;

namespace Planora.Application.Services.AuthService;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessToken(IdentityJwt identityJwt);
    public Task<RefreshToken> CreateRefreshToken(IdentityJwt identityJwt, string ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
}
