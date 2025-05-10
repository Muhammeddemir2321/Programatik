using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.CourseFeature.Constants;
using Planora.Application.Features.CourseFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.CourseFeatures.Queries;

public class ListAllCourseQuery : IRequest<CourseListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.List };

    public class ListAllCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        : IRequestHandler<ListAllCourseQuery, CourseListModel>
    {
        public async Task<CourseListModel> Handle(ListAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await courseRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<CourseListModel>(courses);
        }
    }
}
