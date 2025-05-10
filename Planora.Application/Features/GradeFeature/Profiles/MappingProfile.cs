using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.GradeFeature.Commands;
using Planora.Application.Features.GradeFeature.Dtos;
using Planora.Application.Features.GradeFeature.Models;
using Planora.Domain.Entities;

namespace Planora.Application.Features.GradeFeatures.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Grade, GradeGetByIdDto>().ReverseMap();
        CreateMap<Grade, CreatedGradeDto>().ReverseMap();
        CreateMap<Grade, UpdatedGradeDto>().ReverseMap();
        CreateMap<Grade, GradeListDto>().ReverseMap();
        CreateMap<Grade, CreateGradeCommand>().ReverseMap();
        CreateMap<Grade, UpdateGradeCommand>().ReverseMap();
        CreateMap<IPaginate<Grade>, GradeListModel>().ReverseMap();
    }
}
