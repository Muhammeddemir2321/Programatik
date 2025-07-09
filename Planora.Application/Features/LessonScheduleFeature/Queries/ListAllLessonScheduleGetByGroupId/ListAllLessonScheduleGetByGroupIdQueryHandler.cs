using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;

public class ListAllLessonScheduleGetByGroupIdQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules,
    IMapper mapper)
    : IRequestHandler<ListAllLessonScheduleGetByGroupIdQuery, List<ListAllLessonScheduleGetByGroupIdDto>>
{
    public async Task<List<ListAllLessonScheduleGetByGroupIdDto>> Handle(ListAllLessonScheduleGetByGroupIdQuery request, CancellationToken cancellationToken)
    {
        var lessonSchedules = await planoraUnitOfWork.LessonSchedules.GetAllByGroupIdAsync(request.LessonScheduleGroupId, cancellationToken: cancellationToken);
        return mapper.Map<List<ListAllLessonScheduleGetByGroupIdDto>>(lessonSchedules);
    }
}
