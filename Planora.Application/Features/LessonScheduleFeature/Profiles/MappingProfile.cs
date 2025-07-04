using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LessonSchedule, ListAllLessonScheduleGetByGroupIdDto>().ReverseMap();
        CreateMap<LessonSchedule, CreatedLessonScheduleDto>().ReverseMap();
    }
}
