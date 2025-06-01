using Core.Persistence.Paging;
using Planora.Application.Features.LectureFeature.Dtos;

namespace Planora.Application.Features.LectureFeature.Models;

public class LectureListModel : BasePageableModel
{
    public List<LectureListDto> Items { get; set; }
}
