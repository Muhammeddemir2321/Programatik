using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherFeature.Rules;

public class TeacherBusinessRules(ITeacherRepository teacherRepository)
{
    public async Task TeacherShouldExistWhenRequestedAsync(Teacher teacher)
    {
        if (teacher is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
