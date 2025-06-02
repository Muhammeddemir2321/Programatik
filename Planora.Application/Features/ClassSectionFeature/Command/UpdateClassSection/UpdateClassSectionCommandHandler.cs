using AutoMapper;
using MediatR;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Command.UpdateClassSection;

public class UpdateClassSectionCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdateClassSectionCommand, UpdatedClassSectionDto>
{
    public async Task<UpdatedClassSectionDto> Handle(UpdateClassSectionCommand request, CancellationToken cancellationToken)
    {
        var mappedClassSection = mapper.Map<ClassSection>(request);
        var updatedClassSection = await planoraUnitOfWork.ClassSections.UpdateAsync(mappedClassSection, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedClassSectionDto>(updatedClassSection);
        
    }
}
