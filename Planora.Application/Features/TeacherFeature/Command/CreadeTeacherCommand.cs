using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Planora.Application.Features.TeacherFeature.Constants;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Features.TeacherFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Planora.Application.Features.TeacherFeatures.Commands;

public class CreateTeacherCommand : IRequest<CreatedTeacherDto>, ISecuredRequest
{
    public string FullName { get; set; }
    public Guid LectureId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.Create };
    public class CreateTeachereCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork, IMapper mapper, TeacherBusinessRules teacherBusinessRules)
        : IRequestHandler<CreateTeacherCommand, CreatedTeacherDto>
    {
        public async Task<CreatedTeacherDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var mappedTeacher = mapper.Map<Teacher>(request);
            var createdTeacher = await planoraUnitOfWork.Teachers.AddAsync(mappedTeacher, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<CreatedTeacherDto>(createdTeacher);
        }
    }
}