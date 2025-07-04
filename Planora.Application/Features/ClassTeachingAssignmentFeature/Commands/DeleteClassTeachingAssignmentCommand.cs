using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Commands;

public class DeleteClassTeachingAssignmentCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.Delete };
    public class DeleteClassTeachingAssignmentCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        ClassTeachingAssignmentBusinessRules ClassTeachingAssignmentBusinessRules)
        : IRequestHandler<DeleteClassTeachingAssignmentCommand, bool>
    {
        public async Task<bool> Handle(DeleteClassTeachingAssignmentCommand request, CancellationToken cancellationToken)
        {
            var ClassTeachingAssignment = await planoraUnitOfWork.ClassTeachingAssignments.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await ClassTeachingAssignmentBusinessRules.EntityShouldExistWhenRequestedAsync(ClassTeachingAssignment);
            await planoraUnitOfWork.ClassTeachingAssignments.DeleteAsync(ClassTeachingAssignment!, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return true;

        }
    }

}
