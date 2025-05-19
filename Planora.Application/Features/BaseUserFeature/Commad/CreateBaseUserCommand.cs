using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Constants;
using Planora.Application.Features.BaseUserFeature.Dtos;
using Planora.Application.Features.BaseUserFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.BaseUserFeature.Commad;

public class CreateBaseUserCommand : IRequest<CreatedBaseUserDto>, ISecuredRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.Create };

    public class CreateBaseUserCommandHandler(IBaseUserRepository baseUserRepository, IMapper mapper, BaseUserBusinessRules baseUserBusinessRules)
        : IRequestHandler<CreateBaseUserCommand, CreatedBaseUserDto>
    {
        public async Task<CreatedBaseUserDto> Handle(CreateBaseUserCommand request, CancellationToken cancellationToken)
        {
            await baseUserBusinessRules.UserNameMustBeUniqeWhenCreateAsync(request.Username);
            var mappedUser = mapper.Map<BaseUser>(request);
            var createdUser = await baseUserRepository.AddAsync(mappedUser, request.Password);
            return mapper.Map<CreatedBaseUserDto>(createdUser);
        }
    }
}
