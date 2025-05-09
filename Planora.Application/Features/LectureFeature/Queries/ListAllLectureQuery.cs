using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LectureFeature.Queries;

public class ListAllLectureQuery : IRequest<LectureListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new string[] { LectureClaimConstants.List };

    public class ListAllLectureQueryHandler(ILectureRepository LectureRepository, IMapper mapper)
            : IRequestHandler<ListAllLectureQuery, LectureListModel>
    {
        public async Task<LectureListModel> Handle(ListAllLectureQuery request, CancellationToken cancellationToken)
        {
            var customers = await LectureRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<LectureListModel>(customers);
        }
    }
}
