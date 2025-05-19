using Core.Application.Constants;

namespace Planora.Application.Features.IdentityFeature.Constants
{
    [ClaimConstantGroup("Identity")]
    public class IdentityClaimConstants : BaseClaimConstant
    {
        public const string Create = "Identity.Create";
        public const string Update = "Identity.Update";
        public const string Delete = "Identity.Delete";
        public const string List = "Identity.List";
        public const string ListNotDeleted = "Identity.ListNotDeleted";
        public const string ListDeleted = "Identity.ListDeleted";
        public const string Get = "Identity.Get";
        public const string SoftDelete = "Identity.SoftDelete";
        public const string Restore = "Identity.Restore";
        public const string UpdateStatus = "Identity.UpdateStatus";
        public const string UpdateAuthorities = "Identity.UpdateAuthorities";
        public const string UpdateOperationClaim = "Identity.UpdateOperationClaim";
    }
}
