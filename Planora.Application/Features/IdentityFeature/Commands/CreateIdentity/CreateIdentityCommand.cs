using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commands.CreateIdentity;

public class CreateIdentityCommand : IRequest<CreatedIdentityDto>, ISecuredRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public bool IsPartOfTransaction { get; set; } = false;
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Create };
}
