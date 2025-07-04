using AutoMapper;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailableByDynamic;

public class ListAllTeacherUnavailableByDynamicQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllTeacherUnavailableByDynamicQuery, TeacherUnavailableListModel>
{
    public async Task<TeacherUnavailableListModel> Handle(ListAllTeacherUnavailableByDynamicQuery request, CancellationToken cancellationToken)
    {
        var teacherUnavailables = await planoraUnitOfWork.TeacherUnavailables.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<TeacherUnavailableListModel>(teacherUnavailables);
    }
}
