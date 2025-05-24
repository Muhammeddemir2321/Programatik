using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.HardDeleteIdentity;

public class HardDeleteIdentityCommandHandler(IIdentityRepository identityRepository, IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<HardDeleteIdentityCommand, bool>
{
    public async Task<bool> Handle(HardDeleteIdentityCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        await identityRepository.DeleteAsync(identity);
        return true;
    }
}
