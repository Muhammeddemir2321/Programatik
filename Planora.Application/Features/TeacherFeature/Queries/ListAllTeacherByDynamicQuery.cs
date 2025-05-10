using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeature.Queries;

public class ListAllTeacherByDynamicQuery : IRequest<TeacherListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Query { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.List };

    public class ListAllTeacherByDynamicQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        : IRequestHandler<ListAllTeacherByDynamicQuery, TeacherListModel>
    {
        public async Task<TeacherListModel> Handle(ListAllTeacherByDynamicQuery request, CancellationToken cancellationToken)
        {
            var teachers = await teacherRepository.GetListByDynamicAsync(request.Query, index: request.PageRequest.PageSize,
                size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
            return mapper.Map<TeacherListModel>(teachers);
        }
    }
}
