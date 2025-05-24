using Planora.Application.Features.OperationClaimFeature.Queries.ListAllOperationClaim;

namespace Planora.Application.Features.OperationClaimFeature.Models;
public class OperationClaimListModel
{
    public IList<OperationClaimListDto> Items { get; set; }

}
