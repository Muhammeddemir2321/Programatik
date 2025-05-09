using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Dtos;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.SchoolFeature.Queries;

public class GetByIdSchoolQuery : IRequest<SchoolGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => [SchoolClaimConstants.Get];

    public class GetByIdSchoolQueryHandler
        (ISchoolRepository schoolRepository,
         IMapper mapper,
         SchoolBusinessRules schoolBusinessRules)
        : IRequestHandler<GetByIdSchoolQuery, SchoolGetByIdDto>
    {
        public async Task<SchoolGetByIdDto> Handle(GetByIdSchoolQuery request, CancellationToken cancellationToken)
        {
            var school = await schoolRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

            await schoolBusinessRules.SchoolShouldExistWhenRequested(school);
            return mapper.Map<SchoolGetByIdDto>(school);
        }
    }
}
