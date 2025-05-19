using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Constants;
using Planora.Application.Features.BaseUserFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.BaseUserFeature.Queries;

public class ListAllBaseUserQuery : IRequest<BaseUserListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.List };

    public class ListAllBaseUserQueryHandler(IBaseUserRepository baseUserRepository, IMapper mapper)
        : IRequestHandler<ListAllBaseUserQuery, BaseUserListModel>
    {
        public async Task<BaseUserListModel> Handle(ListAllBaseUserQuery request, CancellationToken cancellationToken)
        {
            var users = await baseUserRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<BaseUserListModel>(users);
        }
    }
}
