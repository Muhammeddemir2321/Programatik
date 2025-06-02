using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;
using Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;
using Planora.Application.Features.ClassSectionFeature.Models;
using Planora.Application.Features.ClassSectionFeature.Queries.GetByIdClassSection;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClassSection, ClassSectionGetByIdDto>().ReverseMap();
        CreateMap<ClassSection, CreatedClassSectionDto>().ReverseMap();
        CreateMap<ClassSection, UpdatedClassSectionDto>().ReverseMap();
        CreateMap<ClassSection, ClassSectionListDto>().ReverseMap();
        CreateMap<ClassSection, CreateClassSectionCommand>().ReverseMap();
        CreateMap<ClassSection, UpdateClassSectionCommand>().ReverseMap();
        CreateMap<IPaginate<ClassSection>, ClassSectionListModel>().ReverseMap();
    }
}
