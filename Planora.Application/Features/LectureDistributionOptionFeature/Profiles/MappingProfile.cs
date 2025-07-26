using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.UpdateLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Models;
using Planora.Application.Features.LectureDistributionOptionFeature.Queries.GetByIdLectureDistributionOption;
using Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LectureDistributionOption, LectureDistributionOptionGetByIdDto>().ReverseMap();
        CreateMap<LectureDistributionOption, CreatedLectureDistributionOptionDto>().ReverseMap();
        CreateMap<LectureDistributionOption, UpdatedLectureDistributionOptionDto>().ReverseMap();
        CreateMap<LectureDistributionOption, LectureDistributionOptionListDto>().ReverseMap();
        CreateMap<LectureDistributionOption, CreateLectureDistributionOptionCommand>().ReverseMap();
        CreateMap<LectureDistributionOption, UpdateLectureDistributionOptionCommand>().ReverseMap();
        CreateMap<IPaginate<LectureDistributionOption>, LectureDistributionOptionListModel>().ReverseMap();
    }
}
