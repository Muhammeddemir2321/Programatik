using Core.Persistence.Controllers;
using Microsoft.AspNetCore.Mvc;
using Planora.Application.Features.AuthFeature.Commands.CreateToken;
using Planora.Application.Features.AuthFeature.Commands.CreateTokenByRefreshToken;

namespace Planora.WabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login( CreateTokenCommand createToken)
        {
            createToken.IpAddress = GetIpAddress() ?? "";
            var result = await Mediator.Send(createToken);
            return Ok(result);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> LoginForRefreshToken(CreateTokenByRefreshTokenCommand createTokenByRefreshToken)
        {
            createTokenByRefreshToken.IpAddress = GetIpAddress() ?? "";
            var result = await Mediator.Send(createTokenByRefreshToken);
            return Ok(result);
        }
    }
}
