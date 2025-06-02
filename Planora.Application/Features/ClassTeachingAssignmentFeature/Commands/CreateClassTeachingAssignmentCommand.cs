using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class CreateClassTeachingAssignmentCommand : IRequest<CreatedClassTeachingAssignmentDto>, ISecuredRequest
{
    public int WeeklyHourCount { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Create };
    public class CreateClassTeachingAssignmenteCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, ClassTeachingAssignmentBusinessRules ClassTeachingAssignmentBusinessRules, IMediator mediator)
        : IRequestHandler<CreateClassTeachingAssignmentCommand, CreatedClassTeachingAssignmentDto>
    {
        public async Task<CreatedClassTeachingAssignmentDto> Handle(CreateClassTeachingAssignmentCommand request, CancellationToken cancellationToken)
        {
            var mappedClassTeachingAssignment = mapper.Map<ClassTeachingAssignment>(request);
            var createdClassTeachingAssignment = await planoraUnitOfWork.ClassTeachingAssignments.AddAsync(mappedClassTeachingAssignment, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<CreatedClassTeachingAssignmentDto>(createdClassTeachingAssignment);
        }
    }
}