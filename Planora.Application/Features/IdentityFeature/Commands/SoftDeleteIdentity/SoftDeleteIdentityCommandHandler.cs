﻿using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.SoftDeleteIdentity;

public class SoftDeleteIdentityCommandHandler(IPlanoraUnitOfWork planoraUnitOfWork, IdentityBusinessRules identityBusinessRules)
   : IRequestHandler<SoftDeleteIdentityCommand, bool>
{
    public async Task<bool> Handle(SoftDeleteIdentityCommand request, CancellationToken cancellationToken)
    {
        var identity = await planoraUnitOfWork.Identities.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        await planoraUnitOfWork.Identities.SoftDeleteAsync(identity);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
