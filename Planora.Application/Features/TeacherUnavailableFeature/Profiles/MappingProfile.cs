using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;
using Planora.Application.Features.UserFeature.Commands.CreateUser;
using Planora.Application.Features.UserFeature.Commands.UpdateUser;
using Planora.Application.Features.UserFeature.Models;
using Planora.Application.Features.UserFeature.Queries.GetByIdUser;
using Planora.Application.Features.UserFeature.Queries.ListAllUser;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {

        CreateMap<TeacherUnavailable, TeacherUnavailableGetByIdDto>().ReverseMap();
        CreateMap<TeacherUnavailable, CreatedTeacherUnavailableDto>().ReverseMap();
        CreateMap<TeacherUnavailable, UpdatedTeacherUnavailableDto>().ReverseMap();
        CreateMap<TeacherUnavailable, TeacherUnavailableListDto>().ReverseMap();
        CreateMap<TeacherUnavailable, CreateTeacherUnavailableCommand>().ReverseMap();
        CreateMap<TeacherUnavailable, UpdateTeacherUnavailableCommand>().ReverseMap();
        CreateMap<IPaginate<TeacherUnavailable>, TeacherUnavailableListModel>().ReverseMap();
    }
}
