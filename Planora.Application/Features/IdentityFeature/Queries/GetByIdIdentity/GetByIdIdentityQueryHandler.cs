using AutoMapper;
using MediatR;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Queries.GetByIdIdentity;

public class GetByIdIdentityQueryHandler(IIdentityRepository identityRepository, IMapper mapper, IdentityBusinessRules identityBusinessRules)
    : IRequestHandler<GetByIdIdentityQuery, IdentityGetByIdDto>
{
    public async Task<IdentityGetByIdDto> Handle(GetByIdIdentityQuery request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await identityBusinessRules.IdentityShouldExistWhenRequestedAsync(identity);
        return mapper.Map<IdentityGetByIdDto>(identity);

    }
}
