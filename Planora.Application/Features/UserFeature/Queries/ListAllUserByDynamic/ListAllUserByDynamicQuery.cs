using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.UserFeature.Constants;
using Planora.Application.Features.UserFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.UserFeature.Queries.ListAllUserByDynamic;

public class ListAllUserByDynamicQuery : IRequest<UserListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { UserClaimConstants.List };
}