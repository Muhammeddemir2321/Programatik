using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;

public class CreateIdentityCommandHandler(IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<CreateIdentityCommand, CreatedIdentityDto>
{
    public async Task<CreatedIdentityDto> Handle(CreateIdentityCommand request, CancellationToken cancellationToken)
    {
        await identityBusinessRules.UserNameMustBeUniqeWhenCreateAsync(request.Username);
        var mappedUser = mapper.Map<Identity>(request);
        var createdUser = await planoraUnitOfWork.Identities.AddAsync(mappedUser, request.Password);
        if (!request.IsPartOfTransaction)
            await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedIdentityDto>(createdUser);
    }
}
