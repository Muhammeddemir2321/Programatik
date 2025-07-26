using Core.Persistence.Paging;
using Planora.Application.Features.LectureDistributionOptionFeature.Queries.ListAllLectureDistributionOption;

namespace Planora.Application.Features.LectureDistributionOptionFeature.Models
{
    public class LectureDistributionOptionListModel : BasePageableModel
    {
        public List<LectureDistributionOptionListDto> Items { get; set; }
    }
}
