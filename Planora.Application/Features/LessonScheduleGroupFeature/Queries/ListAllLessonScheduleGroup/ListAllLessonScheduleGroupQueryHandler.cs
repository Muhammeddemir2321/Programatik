using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Models;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;

public class ListAllLessonScheduleGroupQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper)
    : IRequestHandler<ListAllLessonScheduleGroupQuery, LessonScheduleGroupListModel>
{
    public async Task<LessonScheduleGroupListModel> Handle(ListAllLessonScheduleGroupQuery request, CancellationToken cancellationToken)
    {
        var lessonScheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(cancellationToken: cancellationToken);
        return mapper.Map<LessonScheduleGroupListModel>(lessonScheduleGroups);
    }
}
