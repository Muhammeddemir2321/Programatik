using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.GradeFeatures.Constants;
using Planora.Application.Features.GradeFeatures.Dtos;
using Planora.Application.Features.GradeFeatures.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeatures.Queries;

public class GetByIdGradeQuery : IRequest<GradeGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Get };

    public class GetByIdGradeQueryHandler(IGradeRepository gradeRepository,
                                          IMapper mapper, GradeBusinessRules gradeBusinessRules)
                                          : IRequestHandler<GetByIdGradeQuery, GradeGetByIdDto>
    {
        public async Task<GradeGetByIdDto> Handle(GetByIdGradeQuery request, CancellationToken cancellationToken)
        {
            var grade = await gradeRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);
            await gradeBusinessRules.GradeShouldExistWhenRequested(grade);
            return mapper.Map<GradeGetByIdDto>(grade);
        }
    }
}
