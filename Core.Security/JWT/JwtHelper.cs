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
    public AccessToken CreateToken(IdentityJwt identityJwt)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SigningHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningHelper.CreateSigningCredentials(securityKey);
        var operationClaims = identityJwt.Identity.IdentityOperationClaims.Select(iop => iop.OperationClaim).ToList();
        JwtSecurityToken jwt = CreateJwtSecurityToken(identityJwt, signingCredentials, operationClaims);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken(token, _accessTokenExpiration);
    }
    public RefreshToken CreateRefreshToken(IdentityJwt identityJwt, string ipAddress)
    {
        RefreshToken refreshToken = new()
        {
            IdentityId = identityJwt.Identity.Id,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.UtcNow.AddDays(_tokenOptions.RefreshTokenExpiration),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };

        return refreshToken;
    }
    private JwtSecurityToken CreateJwtSecurityToken(IdentityJwt identityJwt,
                                                   SigningCredentials signingCredentials,
                                                   IList<OperationClaim> operationClaims)
    {
        JwtSecurityToken jwt = new(
            _tokenOptions.Issuer,
            _tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(identityJwt, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }
    private IEnumerable<Claim> SetClaims(IdentityJwt identityJwt, IList<OperationClaim> operationClaims)
    {
        List<Claim> claims = new();
        claims.AddNameIdentifier(identityJwt.Identity.Id.ToString());
        claims.AddUsername(identityJwt.Identity.UserName!);
        //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        claims.AddSchoolId(identityJwt.SchoolId);
        return claims;
    }
}
