using AutoMapper;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;

public class ListAllTeacherUnavailableQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllTeacherUnavailableQuery, TeacherUnavailableListModel>
{
    public async Task<TeacherUnavailableListModel> Handle(ListAllTeacherUnavailableQuery request, CancellationToken cancellationToken)
    {
        var teacherUnavailables = await planoraUnitOfWork.TeacherUnavailables.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<TeacherUnavailableListModel>(teacherUnavailables);
    }
}
