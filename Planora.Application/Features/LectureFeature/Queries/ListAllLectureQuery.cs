using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.LectureFeature.Queries;

public class ListAllLectureQuery : IRequest<LectureListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { LectureClaimConstants.List };

    public class ListAllLectureQueryHandler(ILectureRepository lectureRepository, IMapper mapper)
            : IRequestHandler<ListAllLectureQuery, LectureListModel>
    {
        public async Task<LectureListModel> Handle(ListAllLectureQuery request, CancellationToken cancellationToken)
        {
            var lectures = await lectureRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<LectureListModel>(lectures);
        }
    }
}
