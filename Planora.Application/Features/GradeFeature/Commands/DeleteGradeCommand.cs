using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.GradeFeature.Constants;
using Planora.Application.Features.GradeFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeature.Commands;

public class DeleteGradeCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.Delete };
    public class DeleteGradeCommandHandler(
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
