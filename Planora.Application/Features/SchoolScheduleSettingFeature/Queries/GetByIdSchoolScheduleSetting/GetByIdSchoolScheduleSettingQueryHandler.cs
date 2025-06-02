using AutoMapper;
using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;

public class GetByIdSchoolScheduleSettingQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper,
    SchoolScheduleSettingBusinessRules schoolScheduleSettingBusinessRules)
    : IRequestHandler<GetByIdSchoolScheduleSettingQuery, SchoolScheduleSettingGetByIdDto>
{
    public async Task<SchoolScheduleSettingGetByIdDto> Handle(GetByIdSchoolScheduleSettingQuery request, CancellationToken cancellationToken)
    {
        var setting = await planoraUnitOfWork.SchoolScheduleSettings.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
        await schoolScheduleSettingBusinessRules.UserShouldExistWhenRequestedAsync(setting);
        return mapper.Map<SchoolScheduleSettingGetByIdDto>(setting);
    }
}
