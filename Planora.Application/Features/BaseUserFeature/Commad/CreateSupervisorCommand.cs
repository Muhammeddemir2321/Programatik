using Core.Security.Entities;
using MediatR;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.BaseUserFeature.Commad;

public class CreateSupervisorCommand : IRequest<BaseUser>
{
    public class CreateSupervisorCommandHandler(
        IBaseUserRepository baseUserRepository)
        : IRequestHandler<CreateSupervisorCommand, BaseUser>
    {
        public async Task<BaseUser> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var user = await baseUserRepository.GetAsync(u => u.UserName == "supervisor", cancellationToken: cancellationToken);
            if (user == null)
            {
                user = new BaseUser()
                {
                    FirstName = "Planora",
                    LastName = "Supervisor",
                    UserName = "supervisor",
                    Status = true,
                };
                user = await baseUserRepository.AddAsync(user, "Yalnizyolda0230#");
            }
            return user;
        }
    }
}
