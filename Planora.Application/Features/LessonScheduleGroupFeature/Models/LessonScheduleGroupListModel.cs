using Core.Persistence.Paging;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Models
{
    public class LessonScheduleGroupListModel: BasePageableModel
    {
        public List<LessonScheduleGroupListModel> Items { get; set; }
    }
}
