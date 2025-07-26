using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;

public class CreateLessonScheduleGroupCommandHandler(

    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusiness,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateLessonScheduleGroupCommand, CreatedLessonScheduleGroupDto>
{
    public async Task<CreatedLessonScheduleGroupDto> Handle(CreateLessonScheduleGroupCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var samePeriodActiveGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(
                l => l.IsActive &&
                    l.Year == request.Year &&
                    l.Semester == request.Semester,
                cancellationToken: cancellationToken);
            foreach (var group in samePeriodActiveGroups)
            {
                group.IsActive = false;
                await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(group, cancellationToken: cancellationToken);
            }
            var mappedLessonScheduleGroup = mapper.Map<LessonScheduleGroup>(request);
            mappedLessonScheduleGroup.IsActive = true;

            var createdLessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.AddAsync(mappedLessonScheduleGroup, cancellationToken: cancellationToken);
            request.createLessonScheduleCommand.LessonScheduleGroupId= createdLessonScheduleGroup.Id;
            var mapped = mapper.Map<CreatedLessonScheduleGroupDto>(createdLessonScheduleGroup);
            var createdLessonScheduleGroupDto = await mediator.Send(request.createLessonScheduleCommand);

            mapped.CreatedLessonScheduleDtos = createdLessonScheduleGroupDto.CreatedLessonScheduleDtos;
            mapped.SchoolScheduleSettingGetByIdDto = createdLessonScheduleGroupDto.SchoolScheduleSettingGetByIdDto;
            mapped.classSectionListDtos = createdLessonScheduleGroupDto.classSectionListDtos;
            return mapped;
        });
    }
}
