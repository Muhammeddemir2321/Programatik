using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Planora.Application.Features.TeacherUnavailableFeature.Rules;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.TeacherUnavailableFeature.Commands.CreateTeacherUnavailable;

public class CreateTeacherUnavailableCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    TeacherUnavailableBusinessRules teacherUnavailableBusinessRules)
    : IRequestHandler<CreateTeacherUnavailableCommand, CreatedTeacherUnavailableDto>
{
    public async Task<CreatedTeacherUnavailableDto> Handle(CreateTeacherUnavailableCommand request, CancellationToken cancellationToken)
    {
        var mappedTeacherUnavailable = mapper.Map<TeacherUnavailable>(request);
        var teacher = await planoraUnitOfWork.Teachers.GetAsync(t => t.FakeId == request.TeacherFakeId);
        if (teacher == null)
            throw new BusinessException("Belirtilen FakeId ile eşleşen öğretmen bulunamadı.");

        mappedTeacherUnavailable.TeacherId = teacher.Id;
        var createdTeacherUnavailable = await planoraUnitOfWork.TeacherUnavailables.AddAsync(mappedTeacherUnavailable, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedTeacherUnavailableDto>(createdTeacherUnavailable);
    }
}
