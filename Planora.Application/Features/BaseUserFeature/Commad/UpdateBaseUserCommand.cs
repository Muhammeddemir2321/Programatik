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

public class UpdateBaseUserCommand : IRequest<UpdatedBaseUserDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.Update };

    public class UpdateBaseUserCommandHandler(IBaseUserRepository baseUserRepository, BaseUserBusinessRules baseUserBusinessRules, IMapper mapper)
        : IRequestHandler<UpdateBaseUserCommand, UpdatedBaseUserDto>
    {
        public async Task<UpdatedBaseUserDto> Handle(UpdateBaseUserCommand request, CancellationToken cancellationToken)
        {
            await baseUserBusinessRules.UserNameMustBeUniqueWhenUpdateAsync(request.Id, request.Username);
            var meppedUser = mapper.Map<BaseUser>(request);
            var updatedUser = await baseUserRepository.UpdateAsync(meppedUser);
            return mapper.Map<UpdatedBaseUserDto>(updatedUser);
        }
    }
}
