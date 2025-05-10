using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.LectureFeature.Rules;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeature.Queries;

public class GetByIdTeacherQuery : IRequest<TeacherGetByIdDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.Get };

    public class GetByIdTeacherQueryHanler(ITeacherRepository teacherRepository, IMapper mapper, TeacherBusinessRules teacherBusinessRules)
        : IRequestHandler<GetByIdTeacherQuery, TeacherGetByIdDto>
    {
        public async Task<TeacherGetByIdDto> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher=await teacherRepository.GetAsync(i=>i.Id==request.Id, cancellationToken:cancellationToken);
            await teacherBusinessRules.TeacherShouldExistWhenRequestedAsync(teacher);
            return mapper.Map<TeacherGetByIdDto>(teacher);
        }
    }
}
