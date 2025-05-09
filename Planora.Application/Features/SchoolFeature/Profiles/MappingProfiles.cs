using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.SchoolFeature.Commands;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Models;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolFeature.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<School, SchoolGetByIdDto>().ReverseMap();
        CreateMap<School, CreatedSchoolDto>().ReverseMap();
        CreateMap<School, UpdatedSchoolDto>().ReverseMap();
        CreateMap<School, SchoolListDto>().ReverseMap();
        CreateMap<School, CreateSchoolCommand>().ReverseMap();
        CreateMap<School, UpdateSchoolCommand>().ReverseMap();
        CreateMap<IPaginate<School>, SchoolListModel>().ReverseMap();
    }
}
