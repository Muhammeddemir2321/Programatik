using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityQuery;

public class ListAllIdentityQuery : IRequest<IdentityListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.List };
}
