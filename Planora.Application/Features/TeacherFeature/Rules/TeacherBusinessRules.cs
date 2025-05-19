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
    public async Task TeacherFullNameMustBeUniqeWhenCreateAsync(string fullName)
    {
        var teacher = await teacherRepository.GetAsync(c => c.FullName == fullName);
        if (teacher != null)
            throw new BusinessException("FullName already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("TeacherFullName", fullName ?? string.Empty);
    }
    public async Task TeacherFullNameMustBeUniqueWhenUpdateAsync(Guid id, string fullName)
    {
        var teacher = await teacherRepository.GetAsync(c => c.Id != id && c.FullName == fullName);
        if (teacher != null) throw new BusinessException("FullName already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("teacherFullName", fullName ?? string.Empty);
    }
}
