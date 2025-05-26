using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Commands.DeleteUser;

public class HardDeleteUserCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    UserBusinessRules userBusinessRules,
    IMediator mediator)
    : IRequestHandler<HardDeleteUserCommand, bool>
{
    public async Task<bool> Handle(HardDeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var user = await planoraUnitOfWork.Users.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
            request.HardDeleteIdentityCommand.Id = user!.IdentityId;
            await planoraUnitOfWork.Users.DeleteAsync(user, cancellationToken: cancellationToken);
            await mediator.Send(request.HardDeleteIdentityCommand);
            return true;
        });
    }
}
