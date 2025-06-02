using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.ClassSectionFeature.Queries.GetByIdClassSection;

public class GetByIdClassSectionQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    ClassSectionBusinessRules classSectionBusinessRules,
    IMapper mapper)
    : IRequestHandler<GetByIdClassSectionQuery, ClassSectionGetByIdDto>
{
    public async Task<ClassSectionGetByIdDto> Handle(GetByIdClassSectionQuery request, CancellationToken cancellationToken)
    {
        var classSection = await planoraUnitOfWork.ClassSections.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        await classSectionBusinessRules.UserShouldExistWhenRequestedAsync(classSection);
        return mapper.Map<ClassSectionGetByIdDto>(classSection);
    }
}
