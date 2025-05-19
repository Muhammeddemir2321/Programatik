using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.CourseFeature.Constants;
using Planora.Application.Features.CourseFeature.Dtos;
using Planora.Application.Features.CourseFeature.Rules;
using Planora.Application.Features.LectureFeature.Queries;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.CourseFeatures.Commands;

public class CreateCourseCommand : IRequest<CreatedCourseDto>, ISecuredRequest
{
    public string? WeeklyHours { get; set; }
    public Guid LectureId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.Create };
    public class CreateCourseeCommandHandler(
        ICourseRepository courseRepository, IMapper mapper, CourseBusinessRules courseBusinessRules, IMediator mediator)
        : IRequestHandler<CreateCourseCommand, CreatedCourseDto>
    {
        public async Task<CreatedCourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var lecture = await mediator.Send(new GetByIdLectureQuery { Id = request.LectureId }, cancellationToken);
            var mappedCourse = mapper.Map<Course>(request);
            mappedCourse.Name = lecture.Name!;
            var createdCourse = await courseRepository.AddAsync(mappedCourse, cancellationToken: cancellationToken);
            return mapper.Map<CreatedCourseDto>(createdCourse);
        }
    }
}