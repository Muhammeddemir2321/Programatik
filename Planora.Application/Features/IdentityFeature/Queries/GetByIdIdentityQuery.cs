using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Dtos;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries;

public class GetByIdIdentityQuery : IRequest<IdentityGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Get };

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
}
