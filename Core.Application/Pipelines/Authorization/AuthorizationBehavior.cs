using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (roleClaims == null) throw new AuthorizationException("Claims not found.",ErrorConstants.ClaimNotFound);
        var roles = request.Roles.ToList();
        roles.Add("supervisor");
        bool isNotMatchedARoleClaimWithRequestRoles = roleClaims?.FirstOrDefault(roleClaim => roles.Any(role => role == roleClaim))==null;
        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.",ErrorConstants.YouAreNotAuthorized);

        TResponse response = await next();
        return response;
    }
}