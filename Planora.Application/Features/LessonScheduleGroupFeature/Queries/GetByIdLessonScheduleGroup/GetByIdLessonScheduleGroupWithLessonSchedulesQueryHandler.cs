using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Threading;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class GetByIdLessonScheduleGroupWithLessonSchedulesQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<GetByIdLessonScheduleGroupWithLessonSchedulesQuery, LessonScheduleGroupWithLessonSchedulesGetByIdDto>
{
    public async Task<LessonScheduleGroupWithLessonSchedulesGetByIdDto> Handle(GetByIdLessonScheduleGroupWithLessonSchedulesQuery request, CancellationToken cancellationToken)
    {
        var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id);
        await lessonScheduleGroupBusinesRuless.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
        var lessonSchedulesGetByGrupId = await mediator.Send(new ListAllLessonScheduleGetByGroupIdQuery { LessonScheduleGroupId = request.Id });
        var mapped = mapper.Map<LessonScheduleGroupWithLessonSchedulesGetByIdDto>(lessonScheduleGroup);
        mapped.listAllLessonScheduleGetByGroupIdDtos = lessonSchedulesGetByGrupId;
        return mapped;
    }
}


