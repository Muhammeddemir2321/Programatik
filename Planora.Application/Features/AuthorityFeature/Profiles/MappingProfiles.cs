using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;
using Planora.Application.Features.AuthorityFeature.Commands.UpdateAuthority;
using Planora.Application.Features.AuthorityFeature.Models;
using Planora.Application.Features.AuthorityFeature.Queries.GetByIdAuthority;
using Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;

namespace Uroflow.Application.Features.AuthorityFeature.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Authority, AuthorityGetByIdDto>().ReverseMap();
        CreateMap<Authority, CreatedAuthorityDto>().ReverseMap();
        CreateMap<Authority, UpdatedAuthorityDto>().ReverseMap();
        CreateMap<Authority, AuthorityListDto>().ReverseMap();
        CreateMap<Authority, CreateAuthorityCommand>().ReverseMap();
        CreateMap<Authority, UpdateAuthorityCommand>().ReverseMap();
        CreateMap<IPaginate<Authority>, AuthorityListModel>().ReverseMap();
    }
}
