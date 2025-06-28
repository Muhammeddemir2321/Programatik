using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;

public class CreateLessonScheduleGroupCommandHandler(

    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules userBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateLessonScheduleGroupCommand, CreatedLessonScheduleGroupDto>
{
    public async Task<CreatedLessonScheduleGroupDto> Handle(CreateLessonScheduleGroupCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var aktiveLessonSecheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(l => l.IsActive == true && (l.Year == request.Year && l.Semester == request.Semester), cancellationToken: cancellationToken);
            foreach (var aktiveLessonSecheduleGroup in aktiveLessonSecheduleGroups)
            {
                aktiveLessonSecheduleGroup.IsActive = false;
                await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(aktiveLessonSecheduleGroup, cancellationToken: cancellationToken);
            }
            var mappedLessonScheduleGroup = mapper.Map<LessonScheduleGroup>(request);
            mappedLessonScheduleGroup.IsActive = true;
            var createdLessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.AddAsync(meppedLessonScheduleGroup, cancellationToken: cancellationToken);
            request.createLessonScheduleCommand.LessonScheduleGroupId= createdLessonScheduleGroup.Id;
            await mediator.Send(request.createLessonScheduleCommand);
            return mapper.Map<CreatedLessonScheduleGroupDto>(createdLessonScheduleGroup);
        });
    }
}
