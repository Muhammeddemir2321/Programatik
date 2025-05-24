using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Planora.Application.Features.IdentityFeature.Commands;
using Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;
using Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Features.IdentityFeature.Queries.GetByIdIdentity;
using Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityQuery;

namespace Planora.Application.Features.IdentityFeature.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Identity, IdentityGetByIdDto>().ReverseMap();
        CreateMap<Identity, CreatedIdentityDto>().ReverseMap();
        CreateMap<Identity, UpdatedIdentityDto>().ReverseMap();
        CreateMap<Identity, IdentityListDto>();
        CreateMap<Identity, CreateIdentityCommand>().ReverseMap();
        CreateMap<Identity, UpdateIdentityCommand>().ReverseMap();
        CreateMap<IPaginate<Identity>, IdentityListModel>().ReverseMap();
    }
}
