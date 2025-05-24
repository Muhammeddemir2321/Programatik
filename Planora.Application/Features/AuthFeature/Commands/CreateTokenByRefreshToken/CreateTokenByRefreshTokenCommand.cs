using MediatR;
using Planora.Application.Features.AuthFeature.Commands.CreateToken;

namespace Planora.Application.Features.AuthFeature.Commands.CreateTokenByRefreshToken;

public class CreateTokenByRefreshTokenCommand : IRequest<TokenDto>
{
    public string RefreshToken { get; set; }
    public string IpAddress { get; set; }
}
