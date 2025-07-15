using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherFeature.Models;
using Planora.Application.Services.Repositories;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeatures.Queries;

public class ListTeacherQuery : IRequest<List<TeacherListDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.List };

    public class ListTeacherQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        : IRequestHandler<ListTeacherQuery, List<TeacherListDto>>
    {
        public async Task<List<TeacherListDto>> Handle(ListTeacherQuery request, CancellationToken cancellationToken)
        {
            var teachers = await teacherRepository.GetAllAsync(cancellationToken: cancellationToken);
            return mapper.Map<List<TeacherListDto>>(teachers);
        }
    }
}
