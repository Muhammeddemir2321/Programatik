using AutoMapper;
using MediatR;
using Planora.Application.Features.IdentityFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityByDynamic;

public class ListAllIdentityByDynamicQueryHandler(IIdentityRepository identityRepository, IMapper mapper)
: IRequestHandler<ListAllIdentityByDynamicQuery, IdentityListModel>
{
    public async Task<IdentityListModel> Handle(ListAllIdentityByDynamicQuery request, CancellationToken cancellationToken)
    {
        var identities = await identityRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<IdentityListModel>(identities);
    }
}
