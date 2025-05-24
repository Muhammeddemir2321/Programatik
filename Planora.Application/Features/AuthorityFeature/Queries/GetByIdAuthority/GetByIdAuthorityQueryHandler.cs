using AutoMapper;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Queries.GetByIdAuthority;

public class GetByIdAuthorityQueryHandler(
            IAuthorityRepository authorityRepository,
            IMapper mapper,
            AuthorityBusinessRules authorityBusinessRules)
            : IRequestHandler<GetByIdAuthorityQuery, AuthorityGetByIdDto>
{
    public async Task<AuthorityGetByIdDto> Handle(GetByIdAuthorityQuery request, CancellationToken cancellationToken)
    {
        var authority = await authorityRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);

        return mapper.Map<AuthorityGetByIdDto>(authority);
    }
}
