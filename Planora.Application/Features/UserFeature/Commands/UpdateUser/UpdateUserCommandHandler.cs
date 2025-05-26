using AutoMapper;
using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    UserBusinessRules userBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
{
    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var user = await planoraUnitOfWork.Users.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await userBusinessRules.UserShouldExistWhenRequestedAsync(user);
            request.UpdateIdentityCommand.Id = user!.IdentityId;
            await mediator.Send(request.UpdateIdentityCommand);
            var mappedUser = mapper.Map<User>(request);
            var updatedUser = await planoraUnitOfWork.Users.UpdateAsync(mappedUser, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedUserDto>(updatedUser);
        });
    }
}
