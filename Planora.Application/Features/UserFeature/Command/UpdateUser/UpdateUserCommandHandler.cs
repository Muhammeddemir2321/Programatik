using AutoMapper;
using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Command.UpdateUser;

public class UpdateUserCommandHandler(
    IUserRepository userRepository,
    UserBusinessRules userBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
{
    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
        request.UpdateBaseUserCommand.Id = user!.BaseUserId;
        await mediator.Send(request.UpdateBaseUserCommand);
        var mappedUser = mapper.Map<User>(request);
        var updatedUser = await userRepository.UpdateAsync(mappedUser, cancellationToken: cancellationToken);
        return mapper.Map<UpdatedUserDto>(updatedUser);
    }
}
