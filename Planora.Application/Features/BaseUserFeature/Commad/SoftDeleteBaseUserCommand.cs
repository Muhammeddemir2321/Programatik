using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.BaseUserFeature.Constants;
using Planora.Application.Features.BaseUserFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.BaseUserFeature.Commad;

public class SoftDeleteBaseUserCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { BaseUserClaimConstants.SoftDelete };

    public class SoftDeleteBaseUserCommandHandler(IBaseUserRepository baseUserRepository, BaseUserBusinessRules baseUserBusinessRules)
        : IRequestHandler<HardDeleteBaseUserCommand, bool>
    {
        public async Task<bool> Handle(HardDeleteBaseUserCommand request, CancellationToken cancellationToken)
        {
            var user = await baseUserRepository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            await baseUserBusinessRules.BaseUserShouldExistWhenRequestedAsync(user);
            await baseUserRepository.SoftDeleteAsync(user);
            return true;
        }
    }
}
