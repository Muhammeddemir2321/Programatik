using Core.Persistence.Paging;
using Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;

namespace Planora.Application.Features.OperationClaimFeature.Models;
public class OperationClaimListModel : BasePageableModel
{
    public IList<OperationClaimListDto> Items { get; set; }

}
