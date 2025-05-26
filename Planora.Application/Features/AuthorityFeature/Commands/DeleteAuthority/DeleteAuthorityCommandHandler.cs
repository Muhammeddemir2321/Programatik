using MediatR;
using Planora.Application.Features.AuthorityFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Commands.DeleteAuthority;

public class DeleteAuthorityCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    AuthorityBusinessRules authorityBusinessRules)
    : IRequestHandler<DeleteAuthorityCommand, bool>
{
    public async Task<bool> Handle(DeleteAuthorityCommand request, CancellationToken cancellationToken)
    {
        var authority = await planoraUnitOfWork.Authorities.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
        await authorityBusinessRules.AuthorityShouldExistWhenRequestedAsync(authority);
        await planoraUnitOfWork.Authorities.DeleteAsync(authority, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
