using Core.Application.Constants;

namespace Planora.Application.Features.TeacherFeature.Constants;

[ClaimConstantGroup("Grade")]
public class TeacherClaimConstants
{
    public const string Create = "Teacher.Create";
    public const string Update = "Teacher.Update";
    public const string Delete = "Teacher.Delete";
    public const string List = "Teacher.List";
    public const string ListDeleted = "Teacher.ListDeleted";
    public const string Get = "Teacher.Get";
}
