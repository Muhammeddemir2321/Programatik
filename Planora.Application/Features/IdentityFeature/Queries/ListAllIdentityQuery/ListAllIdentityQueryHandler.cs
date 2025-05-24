using AutoMapper;
using MediatR;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityQuery;

public class ListAllIdentityQueryHandler(IIdentityRepository identityRepository, IMapper mapper)
    : IRequestHandler<ListAllIdentityQuery, IdentityListModel>
{
    public async Task<IdentityListModel> Handle(ListAllIdentityQuery request, CancellationToken cancellationToken)
    {
        var identities = await identityRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<IdentityListModel>(identities);
    }
}
