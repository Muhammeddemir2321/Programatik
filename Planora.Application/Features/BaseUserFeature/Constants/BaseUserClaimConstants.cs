using Core.Application.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planora.Application.Features.BaseUserFeature.Constants
{
    [ClaimConstantGroup("BaseUser")]
    public class BaseUserClaimConstants : BaseClaimConstant
    {
        public const string Create = "BaseUser.Create";
        public const string Update = "BaseUser.Update";
        public const string Delete = "BaseUser.Delete";
        public const string List = "BaseUser.List";
        public const string ListNotDeleted = "BaseUser.ListNotDeleted";
        public const string ListDeleted = "BaseUser.ListDeleted";
        public const string Get = "BaseUser.Get";
        public const string SoftDelete = "BaseUser.SoftDelete";
        public const string Restore = "BaseUser.Restore";
        public const string UpdateStatus = "BaseUser.UpdateStatus";
        public const string UpdateAuthorities = "BaseUser.UpdateAuthorities";
        public const string UpdateOperationClaim = "BaseUser.UpdateOperationClaim";
    }
}
