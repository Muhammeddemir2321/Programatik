using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolFeature.Commands;

public class CreateSchoolCommand : IRequest<CreatedSchoolDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string[] Roles => new string[] { SchoolClaimConstants.Create };

    public class CreateSchoolCommandHandler(
        ISchoolRepository schoolRepository, IMapper mapper, SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<CreateSchoolCommand, CreatedSchoolDto>
    {
        public async Task<CreatedSchoolDto> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            await schoolBusinessRules.SchoolNameMustNotBeEmpty(request.Name);  //Validationda yap
            await schoolBusinessRules.SchoolAddressMustNotBeEmpty(request.Address); //Validationda yap
            await schoolBusinessRules.SchoolNameMustBeUniqeWhenCreate(request.Name);
            var mappedschool = mapper.Map<School>(request);
            var createdschool = await schoolRepository.AddAsync(mappedschool, cancellationToken: cancellationToken);
            return mapper.Map<CreatedSchoolDto>(createdschool);
        }
    }
}
