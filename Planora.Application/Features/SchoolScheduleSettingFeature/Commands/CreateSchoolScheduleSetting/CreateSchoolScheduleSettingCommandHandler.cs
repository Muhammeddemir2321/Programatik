using AutoMapper;
using MediatR;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Commands.CreateSchoolScheduleSetting;

public class CreateSchoolScheduleSettingCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateSchoolScheduleSettingCommand, CreatedSchoolScheduleSettingDto>
{
    public async Task<CreatedSchoolScheduleSettingDto> Handle(CreateSchoolScheduleSettingCommand request, CancellationToken cancellationToken)
    {
        var mappedsetting = mapper.Map<SchoolScheduleSetting>(request);
        var createdsetting = await planoraUnitOfWork.SchoolScheduleSettings.AddAsync(mappedsetting);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<CreatedSchoolScheduleSettingDto>(createdsetting);
    }
}
