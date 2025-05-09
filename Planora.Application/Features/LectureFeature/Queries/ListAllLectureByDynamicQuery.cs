using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.LectureFeature.Constants;
using Planora.Application.Features.LectureFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LectureFeature.Queries;

public class ListAllLectureByDynamicQuery : IRequest<LectureListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    public string[] Roles => new string[] { LectureClaimConstants.List };
    public class ListAllCustomerByDynamicQueryHandler(ILectureRepository LectureRepository, IMapper mapper)
            : IRequestHandler<ListAllLectureByDynamicQuery, LectureListModel>
    {
        public async Task<LectureListModel> Handle(ListAllLectureByDynamicQuery request, CancellationToken cancellationToken)
        {
            var Lecture = await LectureRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            var mappedList = mapper.Map<LectureListModel>(Lecture);
            return mappedList;

        }
    }
}
