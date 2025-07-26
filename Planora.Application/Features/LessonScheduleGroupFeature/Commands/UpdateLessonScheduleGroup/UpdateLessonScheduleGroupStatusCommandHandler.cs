using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.ListAllLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupStatusCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<UpdateLessonScheduleGroupStatusCommand, List<LessonScheduleGroupListDto>>
{
    public async Task<List<LessonScheduleGroupListDto>> Handle(UpdateLessonScheduleGroupStatusCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id, cancellationToken: cancellationToken);
            await lessonScheduleGroupBusinessRules.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
            if (request.IsActive == true)
            {
                var samePeriodActiveGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(
                    l => l.IsActive &&
                        l.Id != lessonScheduleGroup!.Id &&
                        l.Year == lessonScheduleGroup.Year &&
                        l.Semester == lessonScheduleGroup.Semester,
                    cancellationToken: cancellationToken);

                foreach (var group in samePeriodActiveGroups)
                {
                    group.IsActive = false;
                    await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(group, cancellationToken);
                }
            }

            lessonScheduleGroup!.IsActive = request.IsActive;
            await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(lessonScheduleGroup, cancellationToken: cancellationToken);
            var lessonScheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(cancellationToken: cancellationToken);
            return mapper.Map<List<LessonScheduleGroupListDto>>(lessonScheduleGroups);
        });
    }
}
