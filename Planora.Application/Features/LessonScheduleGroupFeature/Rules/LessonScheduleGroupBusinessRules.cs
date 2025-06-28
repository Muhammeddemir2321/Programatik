using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Rules;

public class LessonScheduleGroupBusinessRules
{
    public async Task LessonScheduleGroupShouldExistWhenRequestedAsync(LessonScheduleGroup? lessonScheduleGroup)
    {
        if (lessonScheduleGroup is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
