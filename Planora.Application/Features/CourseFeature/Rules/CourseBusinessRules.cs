using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.CourseFeature.Rules;

public class CourseBusinessRules(ICourseRepository courseRepository)
{
    public async Task CourseShouldExistWhenRequestedAsync(Course course)
    {
        if (course is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
}
