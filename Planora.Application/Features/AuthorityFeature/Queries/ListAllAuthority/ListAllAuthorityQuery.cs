using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using Planora.Application.Features.AuthorityFeature.Models;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;

public class ListAllAuthorityQuery : IRequest<AuthorityListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.List };

}