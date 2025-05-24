using AutoMapper;
using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Commands.CreateUser;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    UserBusinessRules userBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateUserCommand, CreatedUserDto>
{
    public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var createdIdentity=await mediator.Send(request.createIdentityCommand, cancellationToken);
        var mappedUser = mapper.Map<User>(request);
        mappedUser.IsVerify = false;
        mappedUser.IdentityId = createdIdentity.Id;
        var createdUser = await userRepository.AddAsync(mappedUser, cancellationToken: cancellationToken);
        return mapper.Map<CreatedUserDto>(createdUser);
    }
}
