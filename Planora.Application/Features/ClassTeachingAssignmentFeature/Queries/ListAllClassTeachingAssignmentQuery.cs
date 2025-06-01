using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Constants;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.ClassTeachingAssignmentFeatures.Queries;

public class ListAllClassTeachingAssignmentQuery : IRequest<ClassTeachingAssignmentListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { ClassTeachingAssignmentClaimConstants.List };

    public class ListAllClassTeachingAssignmentQueryHandler(IClassTeachingAssignmentRepository ClassTeachingAssignmentRepository, IMapper mapper)
        : IRequestHandler<ListAllClassTeachingAssignmentQuery, ClassTeachingAssignmentListModel>
    {
        public async Task<ClassTeachingAssignmentListModel> Handle(ListAllClassTeachingAssignmentQuery request, CancellationToken cancellationToken)
        {
            var ClassTeachingAssignments = await ClassTeachingAssignmentRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<ClassTeachingAssignmentListModel>(ClassTeachingAssignments);
        }
    }
}
