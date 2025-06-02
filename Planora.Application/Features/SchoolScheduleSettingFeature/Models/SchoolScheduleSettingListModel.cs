using Core.Persistence.Paging;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.ListAllSchoolScheduleSetting;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Models;

public class SchoolScheduleSettingListModel:BasePageableModel
{
    public List<SchoolScheduleSettingListDto> Items { get; set; }
}
