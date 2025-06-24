using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonSchedule;

public class ListAllLessonScheduleQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules,
    IMapper mapper)
    : IRequestHandler<ListAllLessonScheduleQuery, LessonScheduleListDto>
{
    public Task<LessonScheduleListDto> Handle(ListAllLessonScheduleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
