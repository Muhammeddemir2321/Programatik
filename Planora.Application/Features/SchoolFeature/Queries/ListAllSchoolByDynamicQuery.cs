using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.SchoolFeature.Queries;

public class ListAllSchoolByDynamicQuery : IRequest<SchoolListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    public string[] Roles => new string[] { SchoolClaimConstants.List };
    public class ListAllCustomerByDynamicQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
            : IRequestHandler<ListAllSchoolByDynamicQuery, SchoolListModel>
    {
        public async Task<SchoolListModel> Handle(ListAllSchoolByDynamicQuery request, CancellationToken cancellationToken)
        {
            var school = await schoolRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            var mappedList = mapper.Map<SchoolListModel>(school);
            return mappedList;

        }
    }
}
