using MediatR;

namespace Planora.Application.Features.AuthFeature.Commands.CreateToken;

public class CreateTokenCommand : IRequest<TokenDto>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public required string IpAddress { get; set; }
}
