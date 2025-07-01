using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Features.TeacherFeature.Queries;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class CreateClassTeachingAssignmentCommand : IRequest<CreatedClassTeachingAssignmentDto>, ISecuredRequest
{
    public int WeeklyHourCount { get; set; }
    public Guid SchoolId { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Create };
    public class CreateClassTeachingAssignmenteCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, ClassTeachingAssignmentBusinessRules classTeachingAssignmentBusinessRules, IMediator mediator)
        : IRequestHandler<CreateClassTeachingAssignmentCommand, CreatedClassTeachingAssignmentDto>
    {
        public async Task<CreatedClassTeachingAssignmentDto> Handle(CreateClassTeachingAssignmentCommand request, CancellationToken cancellationToken)
        {
            var mappedClassTeachingAssignment = mapper.Map<ClassTeachingAssignment>(request);
            var classSection = await planoraUnitOfWork.ClassSections.GetAsync(c => c.Id == request.ClassSectionId, cancellationToken: cancellationToken);
            var teacher = await planoraUnitOfWork.Teachers.GetAsync(t => t.Id == request.TeacherId, cancellationToken: cancellationToken);
            var lecture = await planoraUnitOfWork.Lectures.GetAsync(l => l.Id == request.LectureId, cancellationToken: cancellationToken);
            await classTeachingAssignmentBusinessRules.EntityShouldExistWhenRequestedAsync(classSection);
            await classTeachingAssignmentBusinessRules.EntityShouldExistWhenRequestedAsync(teacher);
            await classTeachingAssignmentBusinessRules.EntityShouldExistWhenRequestedAsync(lecture);
            mappedClassTeachingAssignment.ClassSectionName = classSection.Name;
            mappedClassTeachingAssignment.TeacherName = teacher.FullName;
            mappedClassTeachingAssignment.LectureName = lecture.Name;
            var createdClassTeachingAssignment = await planoraUnitOfWork.ClassTeachingAssignments.AddAsync(mappedClassTeachingAssignment, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<CreatedClassTeachingAssignmentDto>(createdClassTeachingAssignment);
        }
    }
}