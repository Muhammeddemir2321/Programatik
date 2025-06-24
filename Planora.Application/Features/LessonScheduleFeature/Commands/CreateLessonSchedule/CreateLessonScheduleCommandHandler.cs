using AutoMapper;
using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Features.UserFeature.Commands.CreateUser;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;

public class CreateLessonScheduleCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateLessonScheduleCommand, List<CreatedLessonScheduleDto>>
{
    public async Task<List<CreatedLessonScheduleDto>> Handle(CreateLessonScheduleCommand request, CancellationToken cancellationToken)
    {
        var settings = await planoraUnitOfWork.SchoolScheduleSettings.GetAllAsync(cancellationToken: cancellationToken);
        var classSections = await planoraUnitOfWork.ClassSections.GetAllAsync(cancellationToken: cancellationToken);
        var assignments=await planoraUnitOfWork.ClassTeachingAssignments.GetAllAsync(cancellationToken: cancellationToken);
        var setting = settings.FirstOrDefault();
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
        SlotFinder slotFinder = new SlotFinder(manager, weeklyGrid, setting!.WeeklyLessonDayCount, setting.DailyLessonCount);
        var scheduler = new LessonScheduler();
        List<LessonSchedule> schedules = scheduler.GenerateSchedule(slotFinder, assignments, classSections);
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var createdDtos = schedules.Select(s => mapper.Map<CreatedLessonScheduleDto>(s)).ToList();

            return createdDtos;
        });
        
    }
}
