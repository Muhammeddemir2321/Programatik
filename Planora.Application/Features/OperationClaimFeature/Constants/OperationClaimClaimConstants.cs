using Core.Application.Constants;

namespace Planora.Application.Features.OperationClaimFeature.Constants
{
    [ClaimConstantGroup("OperationClaim")]
    public class OperationClaimClaimConstants: BaseClaimConstant
    {
        public const string Create = "OperationClaim.Create";
        public const string Update = "OperationClaim.Update";
        public const string Delete = "OperationClaim.Delete";
        public const string List = "OperationClaim.List";
        public const string Get = "OperationClaim.Get";
    }
}
