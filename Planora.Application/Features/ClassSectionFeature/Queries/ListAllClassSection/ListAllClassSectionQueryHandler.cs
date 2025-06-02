using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;

public class ListAllClassSectionQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllClassSectionQuery, ClassSectionListModel>
{
    public async Task<ClassSectionListModel> Handle(ListAllClassSectionQuery request, CancellationToken cancellationToken)
    {
        var classSections = await planoraUnitOfWork.ClassSections.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<ClassSectionListModel>(classSections);
    }
}
