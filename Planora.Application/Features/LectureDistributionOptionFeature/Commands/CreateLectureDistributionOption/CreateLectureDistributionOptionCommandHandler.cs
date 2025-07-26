using AutoMapper;
using MediatR;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Text.Json;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;

public class CreateLectureDistributionOptionCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateLectureDistributionOptionCommand, CreatedLectureDistributionOptionDto>
{
    public async Task<CreatedLectureDistributionOptionDto> Handle(CreateLectureDistributionOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = new LectureDistributionOption
        {
            TotalHours = request.TotalHours,
            Distribution = JsonSerializer.Serialize(request.Distribution)
        };
        await planoraUnitOfWork.LectureDistributionOptions.AddAsync(entity);
        await planoraUnitOfWork.CommitAsync();

        return new CreatedLectureDistributionOptionDto
        {
            Id = entity.Id,
            SchoolId = entity.SchoolId,
            TotalHours = entity.TotalHours,
            Distribution = request.Distribution
        };
    }
}
