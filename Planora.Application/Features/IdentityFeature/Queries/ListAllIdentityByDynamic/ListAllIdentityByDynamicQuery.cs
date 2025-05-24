using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityByDynamic;

public class ListAllIdentityByDynamicQuery : IRequest<IdentityListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.List };
}
