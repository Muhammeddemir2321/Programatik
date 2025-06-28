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
        CreateMap<LessonScheduleGroup, LessonScheduleGroupGetByIdDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, CreatedLessonScheduleGroupDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, UpdatedLessonScheduleGroupDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, LessonScheduleGroupListDto>().ReverseMap();
        CreateMap<LessonScheduleGroup, CreateLessonScheduleGroupCommand>().ReverseMap();
        CreateMap<LessonScheduleGroup, UpdateLessonScheduleGroupCommand>().ReverseMap();
        CreateMap<IPaginate<LessonScheduleGroup>, LessonScheduleGroupListModel>().ReverseMap();
    }
}
