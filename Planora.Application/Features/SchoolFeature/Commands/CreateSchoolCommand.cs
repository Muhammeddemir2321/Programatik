﻿using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolFeature.Commands;

public class CreateSchoolCommand : IRequest<CreatedSchoolDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string Address { get; set; }

    [JsonIgnore]
    public string[] Roles => new string[] { SchoolClaimConstants.Create };

    public class CreateSchoolCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<CreateSchoolCommand, CreatedSchoolDto>
    {
        public async Task<CreatedSchoolDto> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            await schoolBusinessRules.SchoolNameMustBeUniqeWhenCreateAsync(request.Name);
            var mappedschool = mapper.Map<School>(request);
            var createdschool = await planoraUnitOfWork.Schools.AddAsync(mappedschool, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<CreatedSchoolDto>(createdschool);
        }
    }
}
