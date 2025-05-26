using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Routing.Constraints;
using Planora.Application.Features.GradeFeature.Constants;
using Planora.Application.Features.GradeFeature.Dtos;
using Planora.Application.Features.GradeFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.GradeFeature.Queries;

public class ListAllGradeQuery : IRequest<GradeListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { GradeClaimConstants.List };

    public class ListAllGradeQueryHandler(IGradeRepository gradeRepository, IMapper mapper)
        : IRequestHandler<ListAllGradeQuery, GradeListModel>
    {
        public async Task<GradeListModel> Handle(ListAllGradeQuery request, CancellationToken cancellationToken)
        {
            var grades=await gradeRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<GradeListModel>(grades);
        }
    }
}
