using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Queries.GetByIdUser;

public class GetByIdUserQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            UserBusinessRules userBusinessRules)
            : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
{
    public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(i => i.Id == request.Id, include: user => user.Include(u => u.BaseUser), cancellationToken: cancellationToken);

        await userBusinessRules.UserShouldExistWhenRequestedAsync(user);

        return mapper.Map<UserGetByIdDto>(user);
    }
}
