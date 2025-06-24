using MediatR;
using Planora.Application.Features.LessonScheduleFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleFeature.Commands.DeleteLessonSchedule;

public class DeleteLessonScheduleCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleBusinessRules lessonScheduleBusinessRules)
    : IRequestHandler<DeleteLessonScheduleCommand, bool>
{
    public Task<bool> Handle(DeleteLessonScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
