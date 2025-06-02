using AutoMapper;
using MediatR;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Command.UpdateSchoolScheduleSetting;

public class UpdateSchoolScheduleSettingCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdateSchoolScheduleSettingCommand, UpdatedSchoolScheduleSettingDto>
{
    public async Task<UpdatedSchoolScheduleSettingDto> Handle(UpdateSchoolScheduleSettingCommand request, CancellationToken cancellationToken)
    {
        var mappedsetting = mapper.Map<SchoolScheduleSetting>(request);
        var updatedSetting = await planoraUnitOfWork.SchoolScheduleSettings.UpdateAsync(mappedsetting, cancellationToken: cancellationToken);
        await planoraUnitOfWork.CommitAsync();
        return mapper.Map<UpdatedSchoolScheduleSettingDto>(updatedSetting);
    }
}
