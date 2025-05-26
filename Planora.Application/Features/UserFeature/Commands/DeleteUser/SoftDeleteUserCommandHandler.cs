using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Commands.DeleteUser;

public class SoftDeleteUserCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    UserBusinessRules userBusinessRules,
    IMediator mediator)
    : IRequestHandler<SoftDeleteUserCommand, bool>
{
    public async Task<bool> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var user = await planoraUnitOfWork.Users.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
            request.SoftDeleteIdentityCommand.Id = user!.IdentityId;
            await planoraUnitOfWork.Users.SoftDeleteAsync(user, cancellationToken: cancellationToken);
            await mediator.Send(request.SoftDeleteIdentityCommand);
            return true;
        });
    }
}
