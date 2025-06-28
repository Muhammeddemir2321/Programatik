using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class GetByIdLessonScheduleGroupQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper)
    : IRequestHandler<GetByIdLessonScheduleGroupQuery, LessonScheduleGroupGetByIdDto>
{
    public async Task<LessonScheduleGroupGetByIdDto> Handle(GetByIdLessonScheduleGroupQuery request, CancellationToken cancellationToken)
    {
        var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id, cancellationToken: cancellationToken);
        await lessonScheduleGroupBusinesRuless.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
        return mapper.Map<LessonScheduleGroupGetByIdDto>(lessonScheduleGroup);
    }
}
