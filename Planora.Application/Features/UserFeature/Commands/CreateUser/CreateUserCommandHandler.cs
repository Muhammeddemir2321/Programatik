using AutoMapper;
using MediatR;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Commands.CreateUser;

public class CreateUserCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    UserBusinessRules userBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateUserCommand, CreatedUserDto>
{
    public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            request.createIdentityCommand.IsPartOfTransaction = true;
            var createdIdentity = await mediator.Send(request.createIdentityCommand, cancellationToken);
            var mappedUser = mapper.Map<User>(request);
            mappedUser.IsVerify = false;
            mappedUser.IdentityId = createdIdentity.Id;
            var createdUser = await planoraUnitOfWork.Users.AddAsync(mappedUser, cancellationToken: cancellationToken);
            return mapper.Map<CreatedUserDto>(createdUser);
        });
        
    }
}
