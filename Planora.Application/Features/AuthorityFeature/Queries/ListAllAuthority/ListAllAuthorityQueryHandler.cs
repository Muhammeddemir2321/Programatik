using AutoMapper;
using MediatR;
using Planora.Application.Features.AuthorityFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;

public class ListAllAuthorityQueryHandler(IAuthorityRepository authorityRepository, IMapper mapper)
    : IRequestHandler<ListAllAuthorityQuery, AuthorityListModel>
{
    public async Task<AuthorityListModel> Handle(ListAllAuthorityQuery request, CancellationToken cancellationToken)
    {
        var authorities = await authorityRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        var mappedList = mapper.Map<AuthorityListModel>(authorities);

        return mappedList;
    }
}
