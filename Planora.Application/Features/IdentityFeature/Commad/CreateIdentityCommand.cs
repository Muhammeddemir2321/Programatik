using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Dtos;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commad;

public class CreateIdentityCommand : IRequest<CreatedIdentityDto>, ISecuredRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Create };

    public class CreateBaseUserCommandHandler(IIdentityRepository baseUserRepository, IMapper mapper, IdentityBusinessRules baseUserBusinessRules)
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
}
