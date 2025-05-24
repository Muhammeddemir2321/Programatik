using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.UserFeature.Commands.CreateUser;
using Planora.Application.Features.UserFeature.Commands.UpdateUser;
using Planora.Application.Features.UserFeature.Models;
using Planora.Application.Features.UserFeature.Queries.GetByIdUser;
using Planora.Application.Features.UserFeature.Queries.ListAllUser;
using Planora.Domain.Entities;

namespace Planora.Application.Features.UserFeature.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserGetByIdDto>().ReverseMap();
        CreateMap<User, CreatedUserDto>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
    }
}
