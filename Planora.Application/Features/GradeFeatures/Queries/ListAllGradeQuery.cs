using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.GradeFeatures.Constants;
using Planora.Application.Features.GradeFeatures.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeatures.Queries;

public class ListAllGradeQuery : IRequest<GradeListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.List };

    public class ListAllGradeQueryHandler(IGradeRepository gradeRepository, IMapper mapper)
        : IRequestHandler<ListAllGradeByDynamicQuery, GradeListModel>
    {
        public async Task<GradeListModel> Handle(ListAllGradeByDynamicQuery request, CancellationToken cancellationToken)
        {
            var grades=await gradeRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<GradeListModel>(grades);
        }
    }
}
