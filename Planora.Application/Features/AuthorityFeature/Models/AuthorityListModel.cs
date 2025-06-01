using Core.Persistence.Paging;
using Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;

namespace Planora.Application.Features.AuthorityFeature.Models;
public class AuthorityListModel:BasePageableModel
{
    public IList<AuthorityListDto> Items { get; set; }

}
