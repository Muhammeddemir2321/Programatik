using AutoMapper;
using Core.Persistence.Repositories;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Features.UserFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;

public class CreateClassSectionCommadHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    ClassSectionBusinessRules<Entity> classSectionBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateClassSectionCommand, CreatedClassSectionDto>
{
    public async Task<CreatedClassSectionDto> Handle(CreateClassSectionCommand request, CancellationToken cancellationToken)
    {
        var mappedClassSection = mapper.Map<ClassSection>(request);
        var createdClassSection = await planoraUnitOfWork.ClassSections.AddAsync(mappedClassSection);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedClassSectionDto>(createdClassSection);
    }
}
