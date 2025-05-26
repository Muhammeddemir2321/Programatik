using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeatures.Commands;

public class DeleteTeacherCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.Delete };
    public class DeleteTeacherCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        TeacherBusinessRules teacherBusinessRules)
        : IRequestHandler<DeleteTeacherCommand, bool>
    {
        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var Teacher = await planoraUnitOfWork.Teachers.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await teacherBusinessRules.TeacherShouldExistWhenRequestedAsync(Teacher);
            await planoraUnitOfWork.Teachers.DeleteAsync(Teacher!, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return true;

        }
    }

}
