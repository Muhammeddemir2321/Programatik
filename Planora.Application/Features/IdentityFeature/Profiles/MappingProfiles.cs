using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Planora.Application.Features.IdentityFeature.Commad;
using Planora.Application.Features.IdentityFeature.Dtos;
using Planora.Application.Features.IdentityFeature.Models;

namespace Planora.Application.Features.IdentityFeature.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Identity, IdentityGetByIdDto>().ReverseMap();
        CreateMap<Identity, CreatedIdentityDto>().ReverseMap();
        CreateMap<Identity, UpdatedIdentityDto>().ReverseMap();
        CreateMap<Identity, IdentityListDto>().ReverseMap();
        CreateMap<Identity, CreateIdentityCommand>().ReverseMap();
        CreateMap<Identity, UpdateIdentityCommand>().ReverseMap();
        CreateMap<IPaginate<Identity>, IdentityListModel>().ReverseMap();
    }
}
