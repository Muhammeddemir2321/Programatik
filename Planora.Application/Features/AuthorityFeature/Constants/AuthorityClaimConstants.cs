using Core.Application.Constants;

namespace Planora.Application.Features.AuthorityFeature.Constants
{
    [ClaimConstantGroup("Authority")]
    public class AuthorityClaimConstants : BaseClaimConstant
    {
        public const string Create = "Authority.Create";
        public const string Update = "Authority.Update";
        public const string Delete = "Authority.Delete";
        public const string List = "Authority.List";
        public const string Get = "Authority.Get";
        public const string UpdateClaims = "Authority.UpdateClaims";
        public const string GetClaimsById = "Authority.GetClaimsById";
    }
}
