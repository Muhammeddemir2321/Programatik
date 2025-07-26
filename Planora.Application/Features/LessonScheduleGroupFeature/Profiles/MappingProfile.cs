using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LessonScheduleGroup, LessonScheduleGroupWithLessonSchedulesGetByIdDto>().ReverseMap();
        CreateMap<IPaginate<LessonScheduleGroup>, LessonScheduleGroupListModel>().ReverseMap();
        CreateMap<LessonScheduleGroup, CreateLessonScheduleGroupCommand>().ReverseMap();
        CreateMap<LessonScheduleGroup, CreatedLessonScheduleGroupDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, UpdateLessonScheduleGroupStatusCommand>().ReverseMap();
        CreateMap<LessonScheduleGroup, UpdateLessonScheduleGroupCommand>().ReverseMap();
        CreateMap<LessonScheduleGroup, UpdatedLessonScheduleGroupDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, LessonScheduleGroupListDto>().ReverseMap();
    }
}
