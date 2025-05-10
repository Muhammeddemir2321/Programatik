using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.CourseFeature.Constants;
using Planora.Application.Features.CourseFeature.Rules;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.CourseFeatures.Commands;

public class DeleteCourseCommand : IRequest<bool>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.Delete };
    public class DeleteCourseCommandHandler(
        ICourseRepository courseRepository,
        CourseBusinessRules courseBusinessRules)
        : IRequestHandler<DeleteCourseCommand, bool>
    {
        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await courseRepository.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await courseBusinessRules.CourseShouldExistWhenRequestedAsync(course);
            await courseRepository.DeleteAsync(course!, cancellationToken: cancellationToken);
            return true;

        }
    }

}
