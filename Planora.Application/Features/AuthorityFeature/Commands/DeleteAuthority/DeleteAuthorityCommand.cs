using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Constants;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.AuthorityFeature.Commands.DeleteAuthority;

public class DeleteAuthorityCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { AuthorityClaimConstants.Delete };
}
