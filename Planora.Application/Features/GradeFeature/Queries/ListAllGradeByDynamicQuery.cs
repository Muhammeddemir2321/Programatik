using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.GradeFeature.Constants;
using Planora.Application.Features.GradeFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeature.Queries;

public class ListAllGradeByDynamicQuery : IRequest<GradeListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.List };

    public class ListAllGradeByDynamicQueryHandler(IGradeRepository gradeRepository, IMapper mapper)
        : IRequestHandler<ListAllGradeByDynamicQuery, GradeListModel>
    {
        public async Task<GradeListModel> Handle(ListAllGradeByDynamicQuery request, CancellationToken cancellationToken)
        {
            var grades = await gradeRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.PageSize,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<GradeListModel>(grades);
        }
    }
}
