using Core.Application.Constants;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Constants;

[ClaimConstantGroup("LessonScheduleGroup")]
public class LessonScheduleGroupClaimConstants : BaseClaimConstant
{
    public const string Create = "LessonScheduleGroup.Create";
    public const string HardDelete = "LessonScheduleGroup.HardDelete";
    public const string SoftDelete = "LessonScheduleGroup.SoftDelete";
    public const string Update = "LessonScheduleGroup.Update";
    public const string List = "LessonScheduleGroup.List";
    public const string Get = "LessonScheduleGroup.Get";
}
