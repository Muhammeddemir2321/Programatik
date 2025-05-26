using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;

public class CreateAuthorityCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<CreateAuthorityCommand, CreatedAuthorityDto>
{
    public async Task<CreatedAuthorityDto> Handle(CreateAuthorityCommand request, CancellationToken cancellationToken)
    {
        await authorityBusinessRules.NameMustBeUniqueWhenCreateAsync(request.Name);
        var mappedAuthority = mapper.Map<Authority>(request);
        var createdAuthority = await planoraUnitOfWork.Authorities.AddAsync(mappedAuthority, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedAuthorityDto>(createdAuthority);
    }
}
