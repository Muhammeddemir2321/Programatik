using Core.Security.Configuration;
using Core.Security.Encryption;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Core.Security.JWT;

public class JwtHelper : ITokenHelper
{
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    public JwtHelper(IOptions<TokenOptions> tokenOptions)
    {
        _tokenOptions = tokenOptions.Value;
    }
    public AccessToken CreateToken(Identity identity)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SigningHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningHelper.CreateSigningCredentials(securityKey);
        var operationClaims = identity.IdentityOperationClaims.Select(iop => iop.OperationClaim).ToList();
        JwtSecurityToken jwt = CreateJwtSecurityToken(identity, signingCredentials, operationClaims);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken(token, _accessTokenExpiration);
    }
    public RefreshToken CreateRefreshToken(Identity identity, string ipAddress)
    {
        RefreshToken refreshToken = new()
        {
            IdentityId = identity.Id,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.UtcNow.AddDays(_tokenOptions.RefreshTokenExpiration),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };

        return refreshToken;
    }
    private JwtSecurityToken CreateJwtSecurityToken(Identity identity,
                                                   SigningCredentials signingCredentials,
                                                   IList<OperationClaim> operationClaims)
    {
        JwtSecurityToken jwt = new(
            _tokenOptions.Issuer,
            _tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(identity, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }
    private IEnumerable<Claim> SetClaims(Identity identity, IList<OperationClaim> operationClaims)
    {
        List<Claim> claims = new();
        claims.AddNameIdentifier(identity.Id.ToString());
        claims.AddUsername(identity.UserName!);
        //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims;
    }
}
