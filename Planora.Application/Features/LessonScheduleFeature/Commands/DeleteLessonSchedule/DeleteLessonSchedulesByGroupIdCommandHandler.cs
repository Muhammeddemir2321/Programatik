using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;

public class DeleteLessonSchedulesByGroupIdCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules)
    : IRequestHandler<DeleteLessonSchedulesByGroupIdCommand, bool>
{
    public async Task<bool> Handle(DeleteLessonSchedulesByGroupIdCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var lessonSchedules = await planoraUnitOfWork.LessonSchedules.GetAllAsync(l => l.LessonScheduleGroupId == request.LessonScheduleGroupId, cancellationToken: cancellationToken);
            foreach (var lessonSchedule in lessonSchedules)
            {
                await planoraUnitOfWork.LessonSchedules.DeleteAsync(lessonSchedule, cancellationToken: cancellationToken);
            }
            return true;
        });
    }
}
