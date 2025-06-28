using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper)
    : IRequestHandler<UpdateLessonScheduleGroupCommand, UpdatedLessonScheduleGroupDto>
{
    public async Task<UpdatedLessonScheduleGroupDto> Handle(UpdateLessonScheduleGroupCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var mappedLessonScheduleGroup = mapper.Map<LessonScheduleGroup>(request);
            var updatedLessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(mappedLessonScheduleGroup, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedLessonScheduleGroupDto>(updatedLessonScheduleGroup);
        });
    }
}
