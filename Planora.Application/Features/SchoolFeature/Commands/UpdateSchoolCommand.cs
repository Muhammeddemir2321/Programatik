using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolFeature.Commands;

public class UpdateSchoolCommand : IRequest<UpdatedSchoolDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { SchoolClaimConstants.Update };



    public class UpdateSchoolCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        IMapper mapper,
        SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<UpdateSchoolCommand, UpdatedSchoolDto>
    {
        public async Task<UpdatedSchoolDto> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            await schoolBusinessRules.SchoolNameMustBeUniqueWhenUpdateAsync(request.Id, request.Name);
            var mappedSchool = mapper.Map<School>(request);
            var updatedSchool = await planoraUnitOfWork.Schools.UpdateAsync(mappedSchool, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<UpdatedSchoolDto>(updatedSchool);
        }
    }

}
