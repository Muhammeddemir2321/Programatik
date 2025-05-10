using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.GradeFeature.Constants;
using Planora.Application.Features.GradeFeature.Dtos;
using Planora.Application.Features.GradeFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeature.Commands;

public class CreateGradeCommand : IRequest<CreatedGradeDto>, ISecuredRequest
{
    public string Name { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Create };
    public class CreateGradeeCommandHandler(
        IGradeRepository gradeRepository, IMapper mapper, GradeBusinessRules gradeBusinessRules)
        : IRequestHandler<CreateGradeCommand, CreatedGradeDto>
    {
        public async Task<CreatedGradeDto> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            await gradeBusinessRules.GradeNameMustBeUniqeWhenCreateAsync(request.Name);
            var mappedGrade = mapper.Map<Grade>(request);
            var createdGrade = await gradeRepository.AddAsync(mappedGrade, cancellationToken: cancellationToken);
            return mapper.Map<CreatedGradeDto>(createdGrade);
        }
    }
}