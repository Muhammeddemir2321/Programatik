using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.GetByIdLessonSchedule;

public class GetByIdLessonScheduleQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules,
    IMapper mapper)
    : IRequestHandler<GetByIdLessonScheduleQuery, LessonScheduleGetByIdDto>
{
    public Task<LessonScheduleGetByIdDto> Handle(GetByIdLessonScheduleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
