using Core.Persistence.Paging;
using Planora.Application.Features.ClassTeachingAssignmentFeature.Dtos;

namespace Planora.Application.Features.ClassTeachingAssignmentFeature.Models;

public class ClassTeachingAssignmentListModel: BasePageableModel
{
    public List<ClassTeachingAssignmentListDto> Items { get; set; }
}
