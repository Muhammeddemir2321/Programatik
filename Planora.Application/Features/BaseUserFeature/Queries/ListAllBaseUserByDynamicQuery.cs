using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Constants;
using Planora.Application.Features.BaseUserFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.BaseUserFeature.Queries;

public class ListAllBaseUserByDynamicQuery : IRequest<BaseUserListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.List };

    public class ListAllBaseUserByDynamicQueryHandler(IBaseUserRepository baseUserRepository, IMapper mapper)
        : IRequestHandler<ListAllBaseUserByDynamicQuery, BaseUserListModel>
    {
        public async Task<BaseUserListModel> Handle(ListAllBaseUserByDynamicQuery request, CancellationToken cancellationToken)
        {
            var users = await baseUserRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<BaseUserListModel>(users);
        }
    }
}
