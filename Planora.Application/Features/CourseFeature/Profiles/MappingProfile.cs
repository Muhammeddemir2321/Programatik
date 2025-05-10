using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.CourseFeature.Dtos;
using Planora.Application.Features.CourseFeature.Models;
using Planora.Application.Features.CourseFeatures.Commands;
using Planora.Domain.Entities;

namespace Planora.Application.Features.CourseFeatures.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseGetByIdDto>().ReverseMap();
        CreateMap<Course, CreatedCourseDto>().ReverseMap();
        CreateMap<Course, UpdatedCourseDto>().ReverseMap();
        CreateMap<Course, CourseListDto>().ReverseMap();
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
        CreateMap<IPaginate<Course>, CourseListModel>().ReverseMap();
    }
}
