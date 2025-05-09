using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LectureFeature.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Lecture, LectureGetByIdDto>().ReverseMap();
        CreateMap<Lecture, CreatedLectureDto>().ReverseMap();
        CreateMap<Lecture, UpdatedLectureDto>().ReverseMap();
        CreateMap<Lecture, LectureListDto>().ReverseMap();
        CreateMap<Lecture, CreateLectureCommand>().ReverseMap();
        CreateMap<Lecture, UpdateLectureCommand>().ReverseMap();
        CreateMap<IPaginate<Lecture>, LectureListModel>().ReverseMap();
    }
}
