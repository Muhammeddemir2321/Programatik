using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.GradeFeatures.Constants;
using Planora.Application.Features.GradeFeatures.Rules;
using Planora.Application.Features.LectureFeature.Commands;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeatures.Commands;

public class DeleteGradeCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Delete };
    public class DeleteLectureCommandHandler(
        IGradeRepository gradeRepository,
        GradeBusinessRules gradeBusinessRules)
        : IRequestHandler<DeleteGradeCommand, bool>
    {
        public async Task<bool> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await gradeRepository.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await gradeBusinessRules.GradeShouldExistWhenRequested(grade);
            await gradeRepository.DeleteAsync(grade!, cancellationToken: cancellationToken);
            return true;

        }
    }
    
    }
