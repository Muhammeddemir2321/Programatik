using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Commands.UpdateAuthority;

public class UpdateAuthorityCommand : IRequest<UpdatedAuthorityDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.Update };
}
