using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Models;
using Planora.Application.Features.SchoolScheduleSettingFeature.Models;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Queries.ListAllSchoolScheduleSetting;

public class ListAllSchoolScheduleSettingQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<ListAllSchoolScheduleSettingQuery, SchoolScheduleSettingListModel>
{
    public async Task<SchoolScheduleSettingListModel> Handle(ListAllSchoolScheduleSettingQuery request, CancellationToken cancellationToken)
    {
        var settings = await planoraUnitOfWork.SchoolScheduleSettings.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);
        return mapper.Map<SchoolScheduleSettingListModel>(settings);
    }
}
