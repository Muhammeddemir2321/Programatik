using Core.Security.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(IdentityJwt identity);
    RefreshToken CreateRefreshToken(IdentityJwt identity, string ipAddress);
}
