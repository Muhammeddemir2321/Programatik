using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Commands.CreateAuthority;
public class CreateAuthorityCommand : IRequest<CreatedAuthorityDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.Create };
}