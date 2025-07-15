using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Application.Features.TeacherFeature.Dtos;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class LessonScheduleGroupWithLessonSchedulesGetByIdDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public List<ListAllLessonScheduleGetByGroupIdDto> listAllLessonScheduleGetByGroupIdDtos { get; set; }
    public List<ClassSectionListDto> classSectionListDtos { get; set; }
    public List<TeacherListDto> teacherListDtos { get; set; }
    public SchoolScheduleSettingGetByIdDto SchoolScheduleSettingGetByIdDto { get; set; }
}
