using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.UpdateAuthority;

public class UpdateAuthorityCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<UpdateAuthorityCommand, UpdatedAuthorityDto>
{
    public async Task<UpdatedAuthorityDto> Handle(UpdateAuthorityCommand request, CancellationToken cancellationToken)
    {
        var mailDesign = await planoraUnitOfWork.Authorities.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(mailDesign);
        await authorityBusinessRules.NameMustBeUniqueWhenUpdateAsync(request.Id, request.Name);
        var mappedAuthority = mapper.Map<Authority>(request);
        var updatedAuthority = await planoraUnitOfWork.Authorities.UpdateAsync(mappedAuthority, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedAuthorityDto>(updatedAuthority);
    }
}
