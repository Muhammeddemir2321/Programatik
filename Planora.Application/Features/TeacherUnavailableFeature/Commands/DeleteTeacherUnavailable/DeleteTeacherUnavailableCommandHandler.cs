using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.DeleteTeacherUnavailable;

public class DeleteTeacherUnavailableCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    TeacherUnavailableBusinessRules teacherUnavailableBusinessRules)
    : IRequestHandler<DeleteTeacherUnavailableCommand, bool>
{
    public async Task<bool> Handle(DeleteTeacherUnavailableCommand request, CancellationToken cancellationToken)
    {
        var teacherUnavailable = await planoraUnitOfWork.TeacherUnavailables.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
        await teacherUnavailableBusinessRules.EntityShouldExistWhenRequestedAsync(teacherUnavailable);
        await planoraUnitOfWork.TeacherUnavailables.DeleteAsync(teacherUnavailable, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
