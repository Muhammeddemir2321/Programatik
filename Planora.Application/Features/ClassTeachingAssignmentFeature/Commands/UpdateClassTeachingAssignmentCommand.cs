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

public class UpdateClassTeachingAssignmentCommand : IRequest<UpdatedClassTeachingAssignmentDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int WeeklyHourCount { get; set; }
    public Guid LectureId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid ClassSectionId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Update };
    public class UpdateClassTeachingAssignmentCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        IMapper mapper,
        ClassTeachingAssignmentBusinessRules ClassTeachingAssignmentBusinessRules, IMediator mediator)
        : IRequestHandler<UpdateClassTeachingAssignmentCommand, UpdatedClassTeachingAssignmentDto>
    {
        public async Task<UpdatedClassTeachingAssignmentDto> Handle(UpdateClassTeachingAssignmentCommand request, CancellationToken cancellationToken)
        {
            var mappedClassTeachingAssignment = mapper.Map<ClassTeachingAssignment>(request);
            var updatedClassTeachingAssignment = await planoraUnitOfWork.ClassTeachingAssignments.UpdateAsync(mappedClassTeachingAssignment, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedClassTeachingAssignmentDto>(updatedClassTeachingAssignment);
        }
    }
}
