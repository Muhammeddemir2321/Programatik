using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Features.LessonScheduleGroupFeature.Constants;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.DeleteLessonScheduleGroup;

public class SoftDeleteLessonScheduleGroupCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless)
    : IRequestHandler<SoftDeleteLessonScheduleGroupCommand, bool>
{
    public async Task<bool> Handle(SoftDeleteLessonScheduleGroupCommand request, CancellationToken cancellationToken)
    {
        var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id);
        await lessonScheduleGroupBusinesRuless.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
        await planoraUnitOfWork.LessonScheduleGroups.SoftDeleteAsync(lessonScheduleGroup!);
        return true;
    }
}
