using AutoMapper;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.TeacherUnavailableFeature.Queries.GetByIdTeacherUnavailable;

public class GetByIdTeacherUnavailableQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    TeacherUnavailableBusinessRules teacherUnavailableBusinessRules)
    : IRequestHandler<GetByIdTeacherUnavailableQuery, TeacherUnavailableGetByIdDto>
{
    public async Task<TeacherUnavailableGetByIdDto> Handle(GetByIdTeacherUnavailableQuery request, CancellationToken cancellationToken)
    {
        var teacherUnavailable = await planoraUnitOfWork.TeacherUnavailables.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
        await teacherUnavailableBusinessRules.EntityShouldExistWhenRequestedAsync(teacherUnavailable);
        return mapper.Map<TeacherUnavailableGetByIdDto>(teacherUnavailable);
    }
}
