using AutoMapper;
using MediatR;
using Planora.Application.Features.LectureDistributionOptionFeature.Commands.CreateLectureDistributionOption;
using Planora.Application.Services.Repositories;
using System.Text.Json;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Queries.GetByIdLectureDistributionOption;

public class GetByIdLectureDistributionOptionQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<GetByIdLectureDistributionOptionQuery, LectureDistributionOptionGetByIdDto>
{
    public async Task<LectureDistributionOptionGetByIdDto> Handle(GetByIdLectureDistributionOptionQuery request, CancellationToken cancellationToken)
    {
        var option = await planoraUnitOfWork.LectureDistributionOptions.GetAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);
        return new LectureDistributionOptionGetByIdDto
        {
            Id = option.Id,
            SchoolId = option.SchoolId,
            TotalHours= option.TotalHours,
            Distribution = string.IsNullOrWhiteSpace(option.Distribution)
                ? new()
                : JsonSerializer.Deserialize<List<int>>(option.Distribution) ?? new()
        };
    }
}
