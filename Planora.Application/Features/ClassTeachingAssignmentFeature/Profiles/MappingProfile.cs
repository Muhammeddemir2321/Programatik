using AutoMapper;
using Core.Persistence.Paging;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Models;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassTeachingAssignmentFeatures.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ClassTeachingAssignment, ClassTeachingAssignmentGetByIdDto>().ReverseMap();
        CreateMap<ClassTeachingAssignment, CreatedClassTeachingAssignmentDto>().ReverseMap();
        CreateMap<ClassTeachingAssignment, UpdatedClassTeachingAssignmentDto>().ReverseMap();
        CreateMap<ClassTeachingAssignment, ClassTeachingAssignmentListDto>().ReverseMap();
        CreateMap<ClassTeachingAssignment, CreateClassTeachingAssignmentCommand>().ReverseMap();
        CreateMap<ClassTeachingAssignment, UpdateClassTeachingAssignmentCommand>().ReverseMap();
        CreateMap<IPaginate<ClassTeachingAssignment>, ClassTeachingAssignmentListModel>().ReverseMap();
    }
}
