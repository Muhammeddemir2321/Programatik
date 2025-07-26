using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;

public class ClassTeachingAssignmentBusinessRules(IPlanoraUnitOfWork planoraUnitOfWork):BaseBusinessRules
{
    public async Task<ClassTeachingAssignment> EnrichClassTeachingAssignmentAsync(ClassTeachingAssignment entity, CancellationToken cancellationToken)
    {
        var classSection = await planoraUnitOfWork.ClassSections.GetAsync(c => c.Id == entity.ClassSectionId, cancellationToken: cancellationToken);
        var teacher = await planoraUnitOfWork.Teachers.GetAsync(t => t.Id == entity.TeacherId, cancellationToken: cancellationToken);
        var lecture = await planoraUnitOfWork.Lectures.GetAsync(l => l.Id == entity.LectureId, cancellationToken: cancellationToken);

        await EntityShouldExistWhenRequestedAsync(classSection);
        await EntityShouldExistWhenRequestedAsync(teacher);
        await EntityShouldExistWhenRequestedAsync(lecture);
        entity.ClassSectionName = classSection.Name;
        entity.TeacherFirstName = teacher.FirstName;
        entity.TeacherLastName = teacher.LastName;
        entity.LectureName = entity.IsOptional == true ? $"SEÇMELİ {lecture.Name}" : lecture.Name;

        return entity;
    }
}
