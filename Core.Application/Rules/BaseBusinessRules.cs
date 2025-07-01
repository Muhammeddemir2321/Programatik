using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;

public class BaseBusinessRules
{
    public async Task EntityShouldExistWhenRequestedAsync(Entity entity)
    {
        if (entity is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
