using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Queries;

public class GetByIdClassTeachingAssignmentQuery : IRequest<ClassTeachingAssignmentGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Get };
    public class GetByIdClassTeachingAssignmentQueryHanler(IClassTeachingAssignmentRepository ClassTeachingAssignmentRepository, IMapper mapper, ClassTeachingAssignmentBusinessRules ClassTeachingAssignmentBusinessRules)
        : IRequestHandler<GetByIdClassTeachingAssignmentQuery, ClassTeachingAssignmentGetByIdDto>
    {
        public async Task<ClassTeachingAssignmentGetByIdDto> Handle(GetByIdClassTeachingAssignmentQuery request, CancellationToken cancellationToken)
        {
            var ClassTeachingAssignment = await ClassTeachingAssignmentRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);
            await ClassTeachingAssignmentBusinessRules.EntityShouldExistWhenRequestedAsync(ClassTeachingAssignment);
            return mapper.Map<ClassTeachingAssignmentGetByIdDto>(ClassTeachingAssignment);
        }
    }
}
