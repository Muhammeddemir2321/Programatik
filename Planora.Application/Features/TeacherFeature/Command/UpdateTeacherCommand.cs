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

public class UpdateTeacherCommand : IRequest<UpdatedTeacherDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.Update };
    public class UpdateTeacherCommandHandler(
        ITeacherRepository teacherRepository,
        IMapper mapper,
        TeacherBusinessRules teacherBusinessRules)
        : IRequestHandler<UpdateTeacherCommand, UpdatedTeacherDto>
    {
        public async Task<UpdatedTeacherDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            await teacherBusinessRules.TeacherFullNameMustBeUniqueWhenUpdate(request.Id, request.FullName);
            var mappedTeacher = mapper.Map<Teacher>(request);
            var updatedTeacher = await teacherRepository.UpdateAsync(mappedTeacher, cancellationToken: cancellationToken);
            return mapper.Map<UpdatedTeacherDto>(updatedTeacher);
        }
    }
}
