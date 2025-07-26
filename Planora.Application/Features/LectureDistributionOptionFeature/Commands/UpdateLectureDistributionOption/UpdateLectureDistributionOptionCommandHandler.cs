using AutoMapper;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.UpdateLectureDistributionOption;

public class UpdateLectureDistributionOptionCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdateLectureDistributionOptionCommand, UpdatedLectureDistributionOptionDto>
{
    public async Task<UpdatedLectureDistributionOptionDto> Handle(UpdateLectureDistributionOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = new LectureDistributionOption
        {
            Id = request.Id,
            TotalHours = request.TotalHours,
            Distribution = JsonSerializer.Serialize(request.Distribution)
        };
        await planoraUnitOfWork.LectureDistributionOptions.UpdateAsync(entity);
        await planoraUnitOfWork.CommitAsync();

        return new UpdatedLectureDistributionOptionDto
        {
            Id = entity.Id,
            SchoolId = entity.SchoolId,
            TotalHours = entity.TotalHours,
            Distribution = request.Distribution
        };
    }
}
