using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LectureFeature.Rules;

public class LectureBusinessRules(ILectureRepository lectureRepository)
{
    public async Task LectureShouldExistWhenRequested(Lecture? Lecture)
    {
        if (Lecture is null)
            throw new BusinessException("Requested record does not exist", ErrorConstants.RequestedRecordDoesNotExist);

        await Task.CompletedTask;
    }
    public async Task LectureNameMustBeUniqeWhenCreate(string? lectureName)
    {
        var lecture = await lectureRepository.GetAsync(c => c.Name == lectureName);
        if (lecture != null)
            throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("LectureName", lectureName ?? string.Empty);
    }
    public async Task LectureNameMustNotBeEmpty(string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new BusinessException("Name must not be empty", ErrorConstants.NameMustNotBeEmpty);
        await Task.CompletedTask;
    }
    public async Task LectureNameMustBeUniqueWhenUpdate(Guid id, string LectureName)
    {
        var Lecture = await lectureRepository.GetAsync(c => c.Id != id && c.Name == LectureName);
        if (Lecture != null) throw new BusinessException("Name already taken", ErrorConstants.NameAlreadyTaken)
                .WithParam("LectureName", LectureName ?? string.Empty);
    }
}
