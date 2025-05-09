using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Xml.Linq;

namespace Planora.Application.Features.SchoolFeature.Rules;

public class SchoolBusinessRules(ISchoolRepository schoolRepository)
{
    public async Task SchoolShouldExistWhenRequested(School? school)
    {
        if (school is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task SchoolNameMustBeUniqeWhenCreate(string? schoolName)
    {
        var school = await schoolRepository.GetAsync(c => c.Name == schoolName);
        if (school != null)
            throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("SchoolName", schoolName ?? string.Empty);
    }
    public async Task SchoolNameMustNotBeEmpty(string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new BusinessException("Name must not be empty", ErrorConstants.NameMustNotBeEmpty);
        await Task.CompletedTask;
    }
    public async Task SchoolAddressMustNotBeEmpty(string? address)
    {
        if (string.IsNullOrEmpty(address))
            throw new BusinessException("Address must not be empty", ErrorConstants.AddressMustNotBeEmpty);
        await Task.CompletedTask;
    }
    public async Task SchoolNameMustBeUniqueWhenUpdate(Guid id, string schoolName)
    {
        var school = await schoolRepository.GetAsync(c => c.Id != id && c.Name == schoolName);
        if (school != null) throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("SchoolName", schoolName ?? string.Empty);
    }
}
