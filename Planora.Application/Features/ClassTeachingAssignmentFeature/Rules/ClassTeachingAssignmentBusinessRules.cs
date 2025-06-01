using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;

public class ClassTeachingAssignmentBusinessRules(IClassTeachingAssignmentRepository ClassTeachingAssignmentRepository)
{
    public async Task ClassTeachingAssignmentShouldExistWhenRequestedAsync(ClassTeachingAssignment ClassTeachingAssignment)
    {
        if (ClassTeachingAssignment is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
