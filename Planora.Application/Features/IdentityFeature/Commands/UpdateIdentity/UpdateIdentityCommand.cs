using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Commands.UpdateIdentity;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commands;

public class UpdateIdentityCommand : IRequest<UpdatedIdentityDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Update };
}
