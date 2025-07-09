using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Application.Features.LessonScheduleFeature.Constraints;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Features.LessonScheduleFeature.Scheduling;
using Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;

public class CreateLessonScheduleCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules,
    IMapper mapper, ILessonScheduler lessonScheduler)
    : IRequestHandler<CreateLessonScheduleCommand, CreatedLessonScheduleGroupDto>
{
    public async Task<CreatedLessonScheduleGroupDto> Handle(CreateLessonScheduleCommand request, CancellationToken cancellationToken)
    {
        var settings = await planoraUnitOfWork.SchoolScheduleSettings.GetAllAsync(cancellationToken: cancellationToken);
        var classSections = await planoraUnitOfWork.ClassSections.GetAllAsync(cancellationToken: cancellationToken);
        CreatedLessonScheduleGroupDto createdLessonScheduleGroupDto = new();
        var assignments=await planoraUnitOfWork.ClassTeachingAssignments.GetAllAsync(cancellationToken: cancellationToken);
        var setting = settings.FirstOrDefault();
        createdLessonScheduleGroupDto.SchoolScheduleSettingGetByIdDto = mapper.Map<SchoolScheduleSettingGetByIdDto>(setting);
        createdLessonScheduleGroupDto.classSectionListDtos = mapper.Map<List<ClassSectionListDto>>(classSections);
        var weeklyGrid = new Dictionary<Guid, LessonSlot[,]>();
        foreach (var classSection in classSections)
        {
            weeklyGrid[classSection.Id] = new LessonSlot[setting!.WeeklyLessonDayCount, setting.DailyLessonCount];
        }
        var constraintFactory = new ConstraintFactory(weeklyGrid);
        var constraintMap = constraintFactory.GetConstraintMap();
        var selectedConstraints = request.SelectedConstraintNames
        .Where(name => constraintMap.ContainsKey(name))
        .Select(name => constraintMap[name]())
        .ToList();
        var manager = new ConstraintManager(selectedConstraints);
        SlotFinder slotFinder = new SlotFinder(request.LessonScheduleGroupId, manager, weeklyGrid, setting!.WeeklyLessonDayCount, setting.DailyLessonCount, planoraUnitOfWork);
        List<LessonSchedule> schedules = lessonScheduler.GenerateSchedule(slotFinder, assignments, classSections);

        foreach (var schedule in schedules)
        {
            await lessonScheduleBusinessRules.LessonScheduleShouldExistWhenRequestedAsync(schedule);
            await planoraUnitOfWork.LessonSchedules.AddAsync(schedule, cancellationToken: cancellationToken);
        }
        var createdDtos = schedules.Select(s => mapper.Map<CreatedLessonScheduleDto>(s)).ToList();

        createdLessonScheduleGroupDto.CreatedLessonScheduleDtos = createdDtos;
        return createdLessonScheduleGroupDto;

    }
}
