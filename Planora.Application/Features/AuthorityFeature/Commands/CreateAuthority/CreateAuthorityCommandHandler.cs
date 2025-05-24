using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;

public class CreateAuthorityCommandHandler(
    IAuthorityRepository authorityRepository,
    IMapper mapper,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<CreateAuthorityCommand, CreatedAuthorityDto>
{
    public async Task<CreatedAuthorityDto> Handle(CreateAuthorityCommand request, CancellationToken cancellationToken)
    {
        await authorityBusinessRules.NameMustBeUniqueWhenCreateAsync(request.Name);
        var mappedAuthority = mapper.Map<Authority>(request);
        var createdAuthority = await authorityRepository.AddAsync(mappedAuthority, cancellationToken: cancellationToken);
        return mapper.Map<CreatedAuthorityDto>(createdAuthority);
    }
}
