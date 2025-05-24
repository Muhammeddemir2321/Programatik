using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;

public class CreateIdentityCommandHandler(IIdentityRepository baseUserRepository, IMapper mapper, IdentityBusinessRules baseUserBusinessRules)
    : IRequestHandler<CreateIdentityCommand, CreatedIdentityDto>
{
    public async Task<CreatedIdentityDto> Handle(CreateIdentityCommand request, CancellationToken cancellationToken)
    {
        await baseUserBusinessRules.UserNameMustBeUniqeWhenCreateAsync(request.Username);
        var mappedUser = mapper.Map<Identity>(request);
        var createdUser = await baseUserRepository.AddAsync(mappedUser, request.Password);
        return mapper.Map<CreatedIdentityDto>(createdUser);
    }
}
