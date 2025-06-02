using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.ClassSectionFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSectionByDynamic;

public class ListAllClassSectionByDynamicQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllClassSectionByDynamicQuery, ClassSectionListModel>
{
    public async Task<ClassSectionListModel> Handle(ListAllClassSectionByDynamicQuery request, CancellationToken cancellationToken)
    {
        var classSections = await planoraUnitOfWork.ClassSections.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<ClassSectionListModel>(classSections);
    }
}
