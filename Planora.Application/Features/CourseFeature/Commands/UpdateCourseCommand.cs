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

public class UpdateCourseCommand : IRequest<UpdatedCourseDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid LectureId { get; set; }
    public string? WeeklyHours { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.Update };
    public class UpdateCourseCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        IMapper mapper,
        CourseBusinessRules courseBusinessRules, IMediator mediator)
        : IRequestHandler<UpdateCourseCommand, UpdatedCourseDto>
    {
        public async Task<UpdatedCourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            GetByIdLectureQuery getLectureQuery = new() { Id = request.LectureId };
            var lecture = await mediator.Send(getLectureQuery, cancellationToken: cancellationToken);
            var mappedCourse = mapper.Map<Course>(request);
            mappedCourse.Name = lecture.Name!;
            var updatedCourse = await planoraUnitOfWork.Courses.UpdateAsync(mappedCourse, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedCourseDto>(updatedCourse);
        }
    }
}
