using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleFeature.Rules;

public class LessonScheduleBusinessRules(ILessonScheduleRepository lessonScheduleRepository)
{
    public async Task UserShouldExistWhenRequestedAsync(LessonSchedule? lessonSchedule)
    {
        if (lessonSchedule is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
