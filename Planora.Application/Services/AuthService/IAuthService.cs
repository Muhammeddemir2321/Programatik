using Core.Security.Entities;
using Core.Security.JWT;

namespace Planora.Application.Services.AuthService;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessToken(Identity identity);
    public Task<RefreshToken> CreateRefreshToken(Identity identity, string ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
}
