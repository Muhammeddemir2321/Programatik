using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Rules;

public class SchoolScheduleSettingBusinessRules
{
    public async Task UserShouldExistWhenRequestedAsync(SchoolScheduleSetting? schoolScheduleSetting)
    {
        if (schoolScheduleSetting is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
