using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;

public class UpdateClassSectionCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    ClassSectionBusinessRules classSectionBusinessRules,
    IMapper mapper)
    : IRequestHandler<UpdateClassSectionCommand, UpdatedClassSectionDto>
{
    public async Task<UpdatedClassSectionDto> Handle(UpdateClassSectionCommand request, CancellationToken cancellationToken)
    {
        var mappedClassSection = mapper.Map<ClassSection>(request);
        var grade = await planoraUnitOfWork.Grades.GetAsync(g => g.Id == request.GradeId, cancellationToken: cancellationToken);

        await classSectionBusinessRules.EntityShouldExistWhenRequestedAsync(grade);
        mappedClassSection.Name = $"{grade!.Name}  {request.Name}";

        var updatedClassSection = await planoraUnitOfWork.ClassSections.UpdateAsync(mappedClassSection, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedClassSectionDto>(updatedClassSection);
        
    }
}
