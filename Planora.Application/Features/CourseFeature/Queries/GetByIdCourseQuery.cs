using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.CourseFeature.Constants;
using Planora.Application.Features.CourseFeature.Dtos;
using Planora.Application.Features.CourseFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.CourseFeature.Queries;

public class GetByIdCourseQuery : IRequest<CourseGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.Get };
    public class GetByIdCourseQueryHanler(ICourseRepository courseRepository, IMapper mapper, CourseBusinessRules courseBusinessRules)
        : IRequestHandler<GetByIdCourseQuery, CourseGetByIdDto>
    {
        public async Task<CourseGetByIdDto> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await courseRepository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);
            await courseBusinessRules.CourseShouldExistWhenRequestedAsync(course);
            return mapper.Map<CourseGetByIdDto>(course);
        }
    }
}
