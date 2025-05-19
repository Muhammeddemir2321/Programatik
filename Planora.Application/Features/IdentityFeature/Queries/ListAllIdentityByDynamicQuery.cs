using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries;

public class ListAllIdentityByDynamicQuery : IRequest<IdentityListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.List };

    public class ListAllIdentityByDynamicQueryHandler(IIdentityRepository identityRepository, IMapper mapper)
        : IRequestHandler<ListAllIdentityByDynamicQuery, IdentityListModel>
    {
        public async Task<IdentityListModel> Handle(ListAllIdentityByDynamicQuery request, CancellationToken cancellationToken)
        {
            var identities = await identityRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<IdentityListModel>(identities);
        }
    }
}
