using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.CourseFeature.Constants;
using Planora.Application.Features.CourseFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.CourseFeature.Queries;

public class ListAllCourseByDynamicQuery : IRequest<CourseListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { CourseClaimConstants.List };

    public class ListAllCourseByDynamicQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        : IRequestHandler<ListAllCourseByDynamicQuery, CourseListModel>
    {
        public async Task<CourseListModel> Handle(ListAllCourseByDynamicQuery request, CancellationToken cancellationToken)
        {
            var courses = await courseRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.PageSize,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<CourseListModel>(courses);
        }
    }
}
