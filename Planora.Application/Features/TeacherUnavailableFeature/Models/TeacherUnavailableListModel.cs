using Core.Persistence.Paging;
using Planora.Application.Features.TeacherUnavailableFeature.Queries.ListAllTeacherUnavailable;

namespace Planora.Application.Features.TeacherUnavailableFeature.Models;

public class TeacherUnavailableListModel:BasePageableModel
{
    public List<TeacherUnavailableListDto> Items { get; set; }
}
