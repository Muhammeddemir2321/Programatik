﻿using Core.Security.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimExtensions
{
    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }
    public static void AddUsername(this ICollection<Claim> claims, string username)
    {
        claims.Add(new Claim(ClaimTypes.Name, username));
    }
    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
    }
    public static void AddSchoolId(this ICollection<Claim> claims, Guid id)
    {
        claims.Add(new Claim("schoolId", id.ToString()));
    }
}
