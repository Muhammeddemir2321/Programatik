using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Command.DeleteUser;

public class HardDeleteCommandHandler(
    IUserRepository userRepository,
    UserBusinessRules userBusinessRules,
    IMediator mediator)
    : IRequestHandler<HardDeleteUserCommand, bool>
{
    public async Task<bool> Handle(HardDeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
        request.HardDeleteBaseUserCommand.Id = user!.BaseUserId;
        await userRepository.DeleteAsync(user, cancellationToken: cancellationToken);
        await mediator.Send(request.HardDeleteBaseUserCommand);
        return true;
    }
}
