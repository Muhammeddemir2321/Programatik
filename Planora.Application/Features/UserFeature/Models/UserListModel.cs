using Core.Persistence.Paging;
using Planora.Application.Features.UserFeature.Queries.ListAllUser;

namespace Planora.Application.Features.UserFeature.Models;

public class UserListModel : BasePageableModel
{
    public List<UserListDto> Items { get; set; }
}
