using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Constants;
using Planora.Application.Features.BaseUserFeature.Dtos;
using Planora.Application.Features.BaseUserFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.BaseUserFeature.Queries;

public class GetByIdBaseUserQuery : IRequest<BaseUserGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.Get };

    public class GetByIdBaseUserQueryHandler(IBaseUserRepository baseUserRepository, IMapper mapper, BaseUserBusinessRules baseUserBusinessRules)
        : IRequestHandler<GetByIdBaseUserQuery, BaseUserGetByIdDto>
    {
        public async Task<BaseUserGetByIdDto> Handle(GetByIdBaseUserQuery request, CancellationToken cancellationToken)
        {
            var user = await baseUserRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await baseUserBusinessRules.BaseUserShouldExistWhenRequestedAsync(user);
            return mapper.Map<BaseUserGetByIdDto>(user);

        }
    }
}
