using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.DeleteAuthority;

public class DeleteAuthorityCommandHandler(
    IAuthorityRepository authorityRepository,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<DeleteAuthorityCommand, bool>
{
    public async Task<bool> Handle(DeleteAuthorityCommand request, CancellationToken cancellationToken)
    {
        var authority = await authorityRepository.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        await authorityRepository.DeleteAsync(authority, cancellationToken: cancellationToken);
        return true;
    }
}
