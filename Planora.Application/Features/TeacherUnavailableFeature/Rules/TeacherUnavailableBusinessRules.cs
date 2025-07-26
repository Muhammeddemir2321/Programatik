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
        public async Task<TeacherUnavailable> CheckCreateTeacherUnavailableModelAsync(TeacherUnavailable teacherUnavailable)
        {
            if (teacherUnavailable.StartHour == 1 && teacherUnavailable.EndHour == 8)
            {
                teacherUnavailable.StartHour = null;
                teacherUnavailable.EndHour = null;
            }
            await Task.CompletedTask;
            return teacherUnavailable;
        }
    }
}
