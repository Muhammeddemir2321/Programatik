using Planora.Application.Features.AuthorityFeature.Queries.ListAllAuthority;

namespace Planora.Application.Features.AuthorityFeature.Models;
public class AuthorityListModel
{
    public IList<AuthorityListDto> Items { get; set; }

}
