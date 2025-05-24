using MediatR;

namespace Planora.Application.Features.AuthFeature.Commands.RevokeRefreshToken;

public class RevokeRefreshTokenCommand : IRequest<bool>
{
    public string RefreshToken { get; set; }
}
