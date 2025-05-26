using Core.Persistence.Paging;
using Planora.Application.Features.GradeFeature.Dtos;

namespace Planora.Application.Features.GradeFeature.Models;

public class GradeListModel:BasePageableModel
{
    public List<GradeListDto> Items { get; set; }
}
