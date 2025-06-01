using Core.Persistence.Paging;
using Planora.Application.Features.SchoolFeature.Dtos;

namespace Planora.Application.Features.SchoolFeature.Models;

public class SchoolListModel : BasePageableModel
{
    public List<SchoolListDto> Items { get; set; }
}
