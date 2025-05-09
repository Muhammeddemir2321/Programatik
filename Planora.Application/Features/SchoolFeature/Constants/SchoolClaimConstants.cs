using Core.Application.Constants;

namespace Planora.Application.Features.SchoolFeature.Constants;

[ClaimConstantGroup("School")]
public class SchoolClaimConstants:BaseClaimConstant
{
    public const string Create = "School.Create";
    public const string Update = "School.Update";
    public const string Delete = "School.Delete";
    public const string List = "School.List";
    public const string ListDeleted = "School.ListDeleted";
    public const string Get = "School.Get";
}
