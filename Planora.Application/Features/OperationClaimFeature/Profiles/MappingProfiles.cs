using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Planora.Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Commands.UpdateOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Models;
using Planora.Application.Features.OperationClaimFeature.Queries.GetByIdOperationClaim;
using Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;

namespace Planora.Application.Features.OperationClaimFeature.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
    }
}
