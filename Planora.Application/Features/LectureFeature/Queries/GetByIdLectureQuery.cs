using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Dtos;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureFeature.Queries;

public class GetByIdLectureQuery : IRequest<LectureGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureClaimConstants.Get };

    public class GetByIdLectureQueryHandler
        (ILectureRepository lectureRepository,
         IMapper mapper,
         LectureBusinessRules LectureBusinessRules)
        : IRequestHandler<GetByIdLectureQuery, LectureGetByIdDto>
    {
        public async Task<LectureGetByIdDto> Handle(GetByIdLectureQuery request, CancellationToken cancellationToken)
        {
            var lecture = await lectureRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

            await LectureBusinessRules.LectureShouldExistWhenRequestedAsync(lecture);
            return mapper.Map<LectureGetByIdDto>(lecture);
        }
    }
}
