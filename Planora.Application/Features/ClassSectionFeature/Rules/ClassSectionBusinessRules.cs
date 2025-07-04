using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;

namespace Planora.Application.Features.ClassSectionFeature.Rules;

public class ClassSectionBusinessRules
{
    public async Task EntityShouldExistWhenRequestedAsync(Entity? entity)
    {
        if (entity is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
