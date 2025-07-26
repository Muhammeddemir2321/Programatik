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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid LectureId { get; set; }
    [JsonIgnore]
    public string[] Roles => new string[] { TeacherClaimConstants.Update };
    public class UpdateTeacherCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        IMapper mapper,
        TeacherBusinessRules teacherBusinessRules)
        : IRequestHandler<UpdateTeacherCommand, UpdatedTeacherDto>
    {
        public async Task<UpdatedTeacherDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var mappedTeacher = mapper.Map<Teacher>(request);
            var updatedTeacher = await planoraUnitOfWork.Teachers.UpdateAsync(mappedTeacher, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return mapper.Map<UpdatedTeacherDto>(updatedTeacher);
        }
    }
}
