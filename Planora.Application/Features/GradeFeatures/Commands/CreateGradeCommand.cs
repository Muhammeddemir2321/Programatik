using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.GradeFeatures.Constants;
using Planora.Application.Features.GradeFeatures.Dtos;
using Planora.Application.Features.GradeFeatures.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeatures.Commands;

public class CreateGradeCommand : IRequest<CreatedGradeDto>, ISecuredRequest
{
    public string Name { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Create };
    public class CreateGradeeCommandHandler(
        IGradeRepository LectureRepository, IMapper mapper, GradeBusinessRules gradeBusinessRules)
        : IRequestHandler<CreateGradeCommand, CreatedGradeDto>
    {
        public async Task<CreatedGradeDto> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            await gradeBusinessRules.GradeNameMustBeUniqeWhenCreate(request.Name);
            var mappedGrade = mapper.Map<Grade>(request);
            var createdGrade = await LectureRepository.AddAsync(mappedGrade, cancellationToken: cancellationToken);
            return mapper.Map<CreatedGradeDto>(createdGrade);
        }
    }
}