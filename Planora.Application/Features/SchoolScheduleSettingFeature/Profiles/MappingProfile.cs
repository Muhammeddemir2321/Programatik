using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.SchoolScheduleSettingFeature.Commands.CreateSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Commands.UpdateSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Models;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.ListAllSchoolScheduleSetting;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SchoolScheduleSetting, SchoolScheduleSettingGetByIdDto>().ReverseMap();
        CreateMap<SchoolScheduleSetting, CreatedSchoolScheduleSettingDto>().ReverseMap();
        CreateMap<SchoolScheduleSetting, UpdatedSchoolScheduleSettingDto>().ReverseMap();
        CreateMap<SchoolScheduleSetting, SchoolScheduleSettingListDto>().ReverseMap();
        CreateMap<SchoolScheduleSetting, CreateSchoolScheduleSettingCommand>().ReverseMap();
        CreateMap<SchoolScheduleSetting, UpdateSchoolScheduleSettingCommand>().ReverseMap();
        CreateMap<IPaginate<SchoolScheduleSetting>, SchoolScheduleSettingListModel>().ReverseMap();
    }
}
