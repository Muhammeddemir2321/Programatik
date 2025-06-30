using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupIsActiveCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<UpdateLessonScheduleGroupIsActiveCommand, List<UpdatedLessonScheduleGroupDto>>
{
    public async Task<List<UpdatedLessonScheduleGroupDto>> Handle(UpdateLessonScheduleGroupIsActiveCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id, cancellationToken: cancellationToken);
            await lessonScheduleGroupBusinessRules.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
            List<LessonScheduleGroup> updatedLessonScheduleGroups = new();
            if (request.IsActive == true)
            {
                var activeLessonScheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(l => l.IsActive == true && (l.Year == lessonScheduleGroup!.Year && l.Semester == lessonScheduleGroup.Semester), cancellationToken: cancellationToken);
                foreach (var activeLessonScheduleGroup in activeLessonScheduleGroups)
                {
                    activeLessonScheduleGroup.IsActive = false;
                    updatedLessonScheduleGroups.Add(await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(activeLessonScheduleGroup, cancellationToken: cancellationToken));
                }
            }

            var mappedLessonScheduleGroup = mapper.Map<LessonScheduleGroup>(request);
            updatedLessonScheduleGroups.Add(await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(mappedLessonScheduleGroup, cancellationToken: cancellationToken));
            return mapper.Map<List<UpdatedLessonScheduleGroupDto>>(updatedLessonScheduleGroups);
        });
    }
}
