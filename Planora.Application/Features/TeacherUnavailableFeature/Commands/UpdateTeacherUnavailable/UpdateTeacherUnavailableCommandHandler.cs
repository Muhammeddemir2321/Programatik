using AutoMapper;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.UpdateTeacherUnavailable;

public class UpdateTeacherUnavailableCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    TeacherUnavailableBusinessRules teacherUnavailableBusinessRules)
    : IRequestHandler<UpdateTeacherUnavailableCommand, UpdatedTeacherUnavailableDto>
{
    public async Task<UpdatedTeacherUnavailableDto> Handle(UpdateTeacherUnavailableCommand request, CancellationToken cancellationToken)
    {
        var mappedTeacherUnavailable=mapper.Map<TeacherUnavailable>(request);
        var teacher = await planoraUnitOfWork.Teachers.GetAsync(t => t.Id == request.TeacherId);

        await teacherUnavailableBusinessRules.EntityShouldExistWhenRequestedAsync(teacher);
        await teacherUnavailableBusinessRules.CheckTeacherUnavailableHourAsync(mappedTeacherUnavailable);

        var updatedTeacherUnavailable = await planoraUnitOfWork.TeacherUnavailables.UpdateAsync(mappedTeacherUnavailable, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedTeacherUnavailableDto>(updatedTeacherUnavailable);
    }
}
