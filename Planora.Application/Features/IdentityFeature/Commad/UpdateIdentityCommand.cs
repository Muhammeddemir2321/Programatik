using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Planora.Application.Features.IdentityFeature.Constants;
using Planora.Application.Features.IdentityFeature.Dtos;
using Planora.Application.Features.IdentityFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.IdentityFeature.Commad;

public class UpdateIdentityCommand : IRequest<UpdatedIdentityDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { IdentityClaimConstants.Update };

    public class UpdateBaseUserCommandHandler(IIdentityRepository identityRepository, IdentityBusinessRules identityBusinessRules, IMapper mapper)
        : IRequestHandler<UpdateIdentityCommand, UpdatedIdentityDto>
    {
        public async Task<UpdatedIdentityDto> Handle(UpdateIdentityCommand request, CancellationToken cancellationToken)
        {
            await identityBusinessRules.UserNameMustBeUniqueWhenUpdateAsync(request.Id, request.Username);
            var mappedIdentity = mapper.Map<Identity>(request);
            var updatedIdentity = await identityRepository.UpdateAsync(mappedIdentity);
            return mapper.Map<UpdatedIdentityDto>(updatedIdentity);
        }
    }
}
