using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;

public class UpdateIdentityCommandHandler(IPlanoraUnitOfWork planoraUnitOfWork, IdentityBusinessRules identityBusinessRules, IMapper mapper)
: IRequestHandler<UpdateIdentityCommand, UpdatedIdentityDto>
{
    public async Task<UpdatedIdentityDto> Handle(UpdateIdentityCommand request, CancellationToken cancellationToken)
    {
        await identityBusinessRules.UserNameMustBeUniqueWhenUpdateAsync(request.Id, request.Username);
        var mappedIdentity = mapper.Map<Identity>(request);
        var updatedIdentity = await planoraUnitOfWork.Identities.UpdateAsync(mappedIdentity);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedIdentityDto>(updatedIdentity);
    }
}
