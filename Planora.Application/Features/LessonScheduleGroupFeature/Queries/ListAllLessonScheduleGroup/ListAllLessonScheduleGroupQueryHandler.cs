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
        var lessonScheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<LessonScheduleGroupListModel>(lessonScheduleGroups);
    }
}
