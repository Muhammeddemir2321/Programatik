using AutoMapper;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Models;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;
using Planora.Application.Features.TeacherUnavailableFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;

public class GetByTeacherIdTeacherUnavailableQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    TeacherUnavailableBusinessRules teacherUnavailableBusinessRules)
    : IRequestHandler<GetByTeacherIdTeacherUnavailableQuery, List<TeacherUnavailableListDto>>
{
    public async Task<List<TeacherUnavailableListDto>> Handle(GetByTeacherIdTeacherUnavailableQuery request, CancellationToken cancellationToken)
    {
        var teacherUnavailable = await planoraUnitOfWork.TeacherUnavailables.GetListByTeacherIdAsync(request.TeacherId, cancellationToken: cancellationToken);

        return mapper.Map<List<TeacherUnavailableListDto>>(teacherUnavailable);
    }
}
