using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Rules;

public class ClassSectionBusinessRules
{
    public async Task UserShouldExistWhenRequestedAsync(ClassSection? classSection)
    {
        if (classSection is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
