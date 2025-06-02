using MediatR;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.ClassSectionFeature.Command.DeleteClassSection;

public class DeleteClassSectionCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    ClassSectionBusinessRules classSectionBusinessRules)
    : IRequestHandler<DeleteClassSectionCommand, bool>
{
    public async Task<bool> Handle(DeleteClassSectionCommand request, CancellationToken cancellationToken)
    {
        var classSection = await planoraUnitOfWork.ClassSections.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        await classSectionBusinessRules.UserShouldExistWhenRequestedAsync(classSection);
        await planoraUnitOfWork.ClassSections.DeleteAsync(classSection!, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return true;
    }
}
