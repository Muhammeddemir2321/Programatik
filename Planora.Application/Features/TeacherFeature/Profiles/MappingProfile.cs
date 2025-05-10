using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherFeature.Models;
using Planora.Application.Features.TeacherFeatures.Commands;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherFeatures.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Teacher, TeacherGetByIdDto>().ReverseMap();
        CreateMap<Teacher, CreatedTeacherDto>().ReverseMap();
        CreateMap<Teacher, UpdatedTeacherDto>().ReverseMap();
        CreateMap<Teacher, TeacherListDto>().ReverseMap();
        CreateMap<Teacher, CreateTeacherCommand>().ReverseMap();
        CreateMap<Teacher, UpdateTeacherCommand>().ReverseMap();
        CreateMap<IPaginate<Teacher>, TeacherListModel>().ReverseMap();
    }
}
