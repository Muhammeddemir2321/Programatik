using Core.Application.Constants;

namespace Planora.Application.Features.ClassSectionFeature.Constants;

[ClaimConstantGroup("ClassSection")]
public class ClassSectionClaimConstants : BaseClaimConstant
{
    public const string Create = "ClassSection.Create";
    public const string Update = "ClassSection.Update";
    public const string List = "ClassSection.List";
    public const string Get = "ClassSection.Get";
    public const string Delete = "ClassSection.Delete";
}
