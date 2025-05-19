using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Planora.Application.Features.BaseUserFeature.Commad;
using Planora.Application.Features.BaseUserFeature.Dtos;
using Planora.Application.Features.BaseUserFeature.Models;

namespace Planora.Application.Features.BaseUserFeature.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<BaseUser, BaseUserGetByIdDto>().ReverseMap();
        CreateMap<BaseUser, CreatedBaseUserDto>().ReverseMap();
        CreateMap<BaseUser, UpdatedBaseUserDto>().ReverseMap();
        CreateMap<BaseUser, BaseUserListDto>().ReverseMap();
        CreateMap<BaseUser, CreateBaseUserCommand>().ReverseMap();
        CreateMap<BaseUser, UpdateBaseUserCommand>().ReverseMap();
        CreateMap<IPaginate<BaseUser>, BaseUserListModel>().ReverseMap();
    }
}
