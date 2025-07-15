using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeatures.Queries;

public class ListAllTeacherQuery : IRequest<TeacherListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.List };

    public class ListAllTeacherQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        : IRequestHandler<ListAllTeacherQuery, TeacherListModel>
    {
        public async Task<TeacherListModel> Handle(ListAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var teachers = await teacherRepository.GetListAsync(cancellationToken: cancellationToken);
            return mapper.Map<TeacherListModel>(teachers);
            //var teachers = await teacherRepository.GetAllAsync(cancellationToken: cancellationToken);
            //return mapper.Map<TeacherListModel>(teachers);
        }
    }
}
