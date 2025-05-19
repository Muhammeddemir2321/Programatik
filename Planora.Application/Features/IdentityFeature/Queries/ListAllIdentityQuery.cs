using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries;

public class ListAllIdentityQuery : IRequest<IdentityListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.List };

    public class ListAllIdentityQueryHandler(IIdentityRepository identityRepository, IMapper mapper)
        : IRequestHandler<ListAllIdentityQuery, IdentityListModel>
    {
        public async Task<IdentityListModel> Handle(ListAllIdentityQuery request, CancellationToken cancellationToken)
        {
            var identities = await identityRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<IdentityListModel>(identities);
        }
    }
}
