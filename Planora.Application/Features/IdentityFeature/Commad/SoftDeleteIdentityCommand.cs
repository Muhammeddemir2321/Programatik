using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commad;

public class SoftDeleteIdentityCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.SoftDelete };

    public class SoftDeleteIdentityCommandHandler(IIdentityRepository identityRepository, IdentityBusinessRules identityBusinessRules)
        : IRequestHandler<SoftDeleteIdentityCommand, bool>
    {
        public async Task<bool> Handle(SoftDeleteIdentityCommand request, CancellationToken cancellationToken)
        {
            var identity = await identityRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
            await identityRepository.SoftDeleteAsync(identity);
            return true;
        }
    }
}
