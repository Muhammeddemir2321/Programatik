using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class CreateClassTeachingAssignmenteCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, ClassTeachingAssignmentBusinessRules classTeachingAssignmentBusinessRules, IMediator mediator)
    : IRequestHandler<CreateClassTeachingAssignmentCommand, CreatedClassTeachingAssignmentDto>
{
    public async Task<CreatedClassTeachingAssignmentDto> Handle(CreateClassTeachingAssignmentCommand request, CancellationToken cancellationToken)
    {
        var mappedClassTeachingAssignment = mapper.Map<ClassTeachingAssignment>(request);
        mappedClassTeachingAssignment = await classTeachingAssignmentBusinessRules.EnrichClassTeachingAssignmentAsync(mappedClassTeachingAssignment, cancellationToken: cancellationToken);
        var createdClassTeachingAssignment = await planoraUnitOfWork.ClassTeachingAssignments.AddAsync(mappedClassTeachingAssignment, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedClassTeachingAssignmentDto>(createdClassTeachingAssignment);
    }
}
