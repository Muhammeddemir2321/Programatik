using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.GradeFeature.Rules;

public class GradeBusinessRules(IGradeRepository gradeRepository)
{
    public async Task GradeShouldExistWhenRequested(Grade grade)
    {
        if (grade is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task GradeNameMustBeUniqeWhenCreate(string name)
    {
        var grade = await gradeRepository.GetAsync(c => c.Name == name);
        if (grade != null)
            throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("GradeName", name ?? string.Empty);
    }
    public async Task GradeNameMustBeUniqueWhenUpdate(Guid id, string name)
    {
        var grade = await gradeRepository.GetAsync(c => c.Id != id && c.Name == name);
        if (grade != null) throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("GradeName", name ?? string.Empty);
    }
}
