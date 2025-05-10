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

public class UpdateGradeCommand : IRequest<UpdatedGradeDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Update };
    public class UpdateGradeCommandHandler(
        IGradeRepository gradeRepository,
        IMapper mapper,
        GradeBusinessRules gradeBusinessRules)
        : IRequestHandler<UpdateGradeCommand, UpdatedGradeDto>
    {
        public async Task<UpdatedGradeDto> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            await gradeBusinessRules.GradeNameMustBeUniqueWhenUpdate(request.Id, request.Name);
            var mappedGrade = mapper.Map<Grade>(request);
            var updatedGrade = await gradeRepository.UpdateAsync(mappedGrade, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedGradeDto>(updatedGrade);
        }
    }
}
