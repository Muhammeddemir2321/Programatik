using AutoMapper;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthorityByDynamic;

public class ListAllAuthorityByDynamicQueryHandler(IAuthorityRepository authorityRepository, IMapper mapper)
    : IRequestHandler<ListAllAuthorityByDynamicQuery, AuthorityListModel>
{
    public async Task<AuthorityListModel> Handle(ListAllAuthorityByDynamicQuery request, CancellationToken cancellationToken)
    {
        var authorities = await authorityRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<AuthorityListModel>(authorities);
        return mappedList;
    }
}
