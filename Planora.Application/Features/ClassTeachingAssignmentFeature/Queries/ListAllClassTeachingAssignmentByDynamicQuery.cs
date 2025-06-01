using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Queries;

public class ListAllClassTeachingAssignmentByDynamicQuery : IRequest<ClassTeachingAssignmentListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.List };

    public class ListAllClassTeachingAssignmentByDynamicQueryHandler(IClassTeachingAssignmentRepository ClassTeachingAssignmentRepository, IMapper mapper)
        : IRequestHandler<ListAllClassTeachingAssignmentByDynamicQuery, ClassTeachingAssignmentListModel>
    {
        public async Task<ClassTeachingAssignmentListModel> Handle(ListAllClassTeachingAssignmentByDynamicQuery request, CancellationToken cancellationToken)
        {
            var ClassTeachingAssignments = await ClassTeachingAssignmentRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.PageSize,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<ClassTeachingAssignmentListModel>(ClassTeachingAssignments);
        }
    }
}
