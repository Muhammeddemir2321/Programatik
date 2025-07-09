using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.ClassSectionFeature.Command.CreateClassSection;

public class CreateClassSectionCommadHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    ClassSectionBusinessRules classSectionBusinessRules,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<CreateClassSectionCommand, CreatedClassSectionDto>
{
    public async Task<CreatedClassSectionDto> Handle(CreateClassSectionCommand request, CancellationToken cancellationToken)
    {
        var mappedClassSection = mapper.Map<ClassSection>(request);
        mappedClassSection.GradeId= Guid.Parse("D281D7DC-0FFD-41DD-50A4-08DDBB11CFE5");
        //var grade = await planoraUnitOfWork.Grades.GetAsync(g => g.Id == request.GradeId, cancellationToken: cancellationToken);,,,,
        //await classSectionBusinessRules.EntityShouldExistWhenRequestedAsync(grade);
        //mappedClassSection.Name = $"{request.Name}  {grade!.Name}";
        var createdClassSection = await planoraUnitOfWork.ClassSections.AddAsync(mappedClassSection);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedClassSectionDto>(createdClassSection);
    }
}
