using Core.Application.Constants;

namespace Planora.Application.Features.UserFeature.Constants;

[ClaimConstantGroup("User")]
public class UserClaimConstants : BaseClaimConstant
{
    public const string Create = "User.Create";
    public const string Update = "User.Update";
    public const string List = "User.List";
    public const string ListNotDeleted = "User.ListNotDeleted";
    public const string ListDeleted = "User.ListDeleted";
    public const string Get = "User.Get";
    public const string UpdateUserName = "User.UpdateUserName";
    public const string HardDelete = "User.HardDelete";
    public const string SoftDelete = "User.SoftDelete";
}
