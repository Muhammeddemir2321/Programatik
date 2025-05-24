using Core.Security.Entities;
using MediatR;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Commands.CreateSupervisor;

public class CreateSupervisorCommandHandler(
    IIdentityRepository identityRepository)
    : IRequestHandler<CreateSupervisorCommand, Identity>
{
    public async Task<Identity> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
    {
        var identity = await identityRepository.GetAsync(u => u.UserName == "supervisor", cancellationToken: cancellationToken);
        if (identity == null)
        {
            identity = new Identity()
            {
                FirstName = "Planora",
                LastName = "Supervisor",
                UserName = "supervisor",
                Status = true,
            };
            identity = await identityRepository.AddAsync(identity, "Yalnizyolda0230#");
        }
        return identity;
    }
}
