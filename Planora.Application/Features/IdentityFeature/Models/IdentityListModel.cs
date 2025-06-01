using Core.Persistence.Paging;
using Planora.Application.Features.IdentityFeature.Queries.ListAllIdentityQuery;

namespace Planora.Application.Features.IdentityFeature.Models;

public class IdentityListModel : BasePageableModel
{
    public List<IdentityListDto> Items { get; set; }
}
