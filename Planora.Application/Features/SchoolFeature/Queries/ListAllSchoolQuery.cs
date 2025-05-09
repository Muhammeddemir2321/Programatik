using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.SchoolFeature.Constants;
using Planora.Application.Features.SchoolFeature.Models;
using Planora.Application.Features.SchoolFeature.Rules;
using Planora.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planora.Application.Features.SchoolFeature.Queries;

public class ListAllSchoolQuery : IRequest<SchoolListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new string[] { SchoolClaimConstants.List };

    public class ListAllSchoolQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
            : IRequestHandler<ListAllSchoolQuery, SchoolListModel>
    {
        public async Task<SchoolListModel> Handle(ListAllSchoolQuery request, CancellationToken cancellationToken)
        {
            var customers = await schoolRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<SchoolListModel>(customers);
        }
    }
}
