using Core.Persistence.Paging;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;

namespace Planora.Application.Features.ClassSectionFeature.Models;

public class ClassSectionListModel:BasePageableModel
{
    public List<ClassSectionListDto> Items { get; set; }
}
