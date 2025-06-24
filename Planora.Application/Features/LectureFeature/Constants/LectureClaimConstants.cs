using Core.Application.Constants;

namespace Planora.Application.Features.LectureFeature.Constants;

[ClaimConstantGroup("Lecture")]
public class LectureClaimConstants : BaseClaimConstant
{
    public const string Create = "Lecture.Create";
    public const string Update = "Lecture.Update";
    public const string Delete = "Lecture.Delete";
    public const string List = "Lecture.List";
    public const string ListDeleted = "Lecture.ListDeleted";
    public const string Get = "Lecture.Get";
}
