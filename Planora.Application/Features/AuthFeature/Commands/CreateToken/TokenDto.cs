using Core.Security.JWT;

namespace Planora.Application.Features.AuthFeature.Commands.CreateToken;

public class TokenDto
{
    public required AccessToken AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}
