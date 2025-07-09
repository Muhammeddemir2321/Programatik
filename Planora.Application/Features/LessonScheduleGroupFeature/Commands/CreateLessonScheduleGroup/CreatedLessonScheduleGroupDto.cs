using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Application.Features.LessonScheduleFeature.Commands.CreateLessonSchedule;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.CreateLessonScheduleGroup;

public class CreatedLessonScheduleGroupDto
{
    public Guid Id { get; set; }
    public Guid SchoolId { get; set; }
    public int Semester { get; set; }           
    public int Year { get; set; }          
    public string Description { get; set; }     
    public bool IsActive { get; set; }
    public List<CreatedLessonScheduleDto> CreatedLessonScheduleDtos { get; set; }
    public List<ClassSectionListDto> classSectionListDtos { get; set; }
    public SchoolScheduleSettingGetByIdDto SchoolScheduleSettingGetByIdDto { get; set; }
}
