using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Rules
{
    public class TeacherUnavailableBusinessRules(ITeacherUnavailableRepository teacherUnavailableRepository)
    {
        public async Task EntityShouldExistWhenRequestedAsync(Entity? entity)
        {
            if (entity is null)
                throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

            await Task.CompletedTask;
        }
    }
}
