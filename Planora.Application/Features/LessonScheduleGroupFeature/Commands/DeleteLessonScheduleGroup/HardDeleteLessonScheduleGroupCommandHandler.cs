using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.DeleteLessonScheduleGroup;

public class HardDeleteLessonScheduleGroupCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<HardDeleteLessonScheduleGroupCommand, bool>
{
    public async Task<bool> Handle(HardDeleteLessonScheduleGroupCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id, cancellationToken: cancellationToken);
            await lessonScheduleGroupBusinesRuless.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
            request.DeleteLessonSchedulesByGroupIdCommand.LessonScheduleGroupId = lessonScheduleGroup!.Id;
            await mediator.Send(request.DeleteLessonSchedulesByGroupIdCommand);
            await planoraUnitOfWork.LessonScheduleGroups.DeleteAsync(lessonScheduleGroup!, cancellationToken: cancellationToken);
            if (lessonScheduleGroup.IsActive == true)
            {
                var lastGroup = (await planoraUnitOfWork.LessonScheduleGroups
                    .GetAllAsync(l => (l.Year == lessonScheduleGroup.Year && l.Semester == lessonScheduleGroup.Semester), orderBy: q => q.OrderByDescending(x => x.CreatedAt))).FirstOrDefault();
                var mappedLessonScheduleGroup = mapper.Map<UpdateLessonScheduleGroupStatusCommand>(lastGroup);
                mappedLessonScheduleGroup.IsActive = true;
                await mediator.Send(mappedLessonScheduleGroup);
            }
            return true;
        });
    }
}
