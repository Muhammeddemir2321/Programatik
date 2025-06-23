using Core.Application.Constants;

namespace Planora.Application.Features.LessonScheduleFeature.Constants;

[ClaimConstantGroup("LessonSchedule")]
public class LessonScheduleClaimConstants : BaseClaimConstant
{
    public const string Create = "LessonSchedule.Create";
    public const string List = "LessonSchedule.List";
    public const string Get = "LessonSchedule.Get";
    public const string Delete = "LessonSchedule.Delete";
}
