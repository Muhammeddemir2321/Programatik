using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Command.DeleteUser;

public class SoftDeleteUserCommandHandler(
    IUserRepository userRepository,
    UserBusinessRules userBusinessRules,
    IMediator mediator)
    : IRequestHandler<SoftDeleteUserCommand, bool>
{
    public async Task<bool> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
        request.SoftDeleteBaseUserCommand.Id = user!.BaseUserId;
        await userRepository.SoftDeleteAsync(user, cancellationToken: cancellationToken);
        await mediator.Send(request.SoftDeleteBaseUserCommand);
        return true;
    }
}
