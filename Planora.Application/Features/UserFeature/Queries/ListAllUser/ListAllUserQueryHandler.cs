using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.UserFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Queries.ListAllUser;

public class ListAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
   : IRequestHandler<ListAllUserQuery, UserListModel>
{
    public async Task<UserListModel> Handle(ListAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetListAsync(include: user => user.Include(u => u.BaseUser),
            index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<UserListModel>(users);

        return mappedList;
    }
}
