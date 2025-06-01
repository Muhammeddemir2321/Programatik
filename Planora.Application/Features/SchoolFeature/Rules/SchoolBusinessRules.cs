using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Xml.Linq;

namespace Planora.Application.Features.SchoolFeature.Rules;

public class SchoolBusinessRules(ISchoolRepository schoolRepository)
{
    public async Task SchoolShouldExistWhenRequestedAsync(School? school)
    {
        if (school is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task SchoolNameMustBeUniqeWhenCreateAsync(string? schoolName)
    {
        var school = await schoolRepository.GetAsync(c => c.Name == schoolName);
        if (school != null)
            throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("SchoolName", schoolName ?? string.Empty);
    }
    public async Task SchoolNameMustBeUniqueWhenUpdateAsync(Guid id, string schoolName)
    {
        var school = await schoolRepository.GetAsync(c => c.Id != id && c.Name == schoolName);
        if (school != null) throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("SchoolName", schoolName ?? string.Empty);
    }
}
