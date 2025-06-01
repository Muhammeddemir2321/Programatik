using Core.Persistence.Paging;
using Planora.Application.Features.TeacherFeature.Dtos;

namespace Planora.Application.Features.TeacherFeature.Models;

public class TeacherListModel : BasePageableModel
{
    public List<TeacherListDto> Items { get; set; }
}
