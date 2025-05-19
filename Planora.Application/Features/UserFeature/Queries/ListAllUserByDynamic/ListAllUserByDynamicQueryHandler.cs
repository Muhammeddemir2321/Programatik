using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.UserFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.UserFeature.Queries.ListAllUserByDynamic;

public class ListAllUserByDynamicQueryHandler(IUserRepository userRepository, IMapper mapper)
        : IRequestHandler<ListAllUserByDynamicQuery, UserListModel>
{
    public async Task<UserListModel> Handle(ListAllUserByDynamicQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetListByDynamicAsync(request.Query, include: user => user.Include(u => u.BaseUser), index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<UserListModel>(users);
        return mappedList;
    }
}
