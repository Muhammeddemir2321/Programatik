using AutoMapper;
using MediatR;
using Planora.Application.Features.ClassSectionFeature.Queries.ListAllClassSection;
using Planora.Application.Features.LessonScheduleFeature.Queries.ListAllLessonScheduleGetByGroupId;
using Planora.Application.Features.LessonScheduleGroupFeature.Rules;
using Planora.Application.Features.SchoolScheduleSettingFeature.Queries.GetByIdSchoolScheduleSetting;
using Planora.Application.Features.TeacherFeature.Dtos;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Queries.GetByIdLessonScheduleGroup;

public class GetByIdLessonScheduleGroupWithLessonSchedulesQueryHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    LessonScheduleGroupBusinessRules lessonScheduleGroupBusinesRuless,
    IMapper mapper,
    IMediator mediator)
    : IRequestHandler<GetByIdLessonScheduleGroupWithLessonSchedulesQuery, LessonScheduleGroupWithLessonSchedulesGetByIdDto>
{
    public async Task<LessonScheduleGroupWithLessonSchedulesGetByIdDto> Handle(GetByIdLessonScheduleGroupWithLessonSchedulesQuery request, CancellationToken cancellationToken)
    {
        var settings = await planoraUnitOfWork.SchoolScheduleSettings.GetAllAsync(cancellationToken: cancellationToken);
        var setting = settings.FirstOrDefault();
        var classSections = await planoraUnitOfWork.ClassSections.GetAllAsync(cancellationToken: cancellationToken);
        var teachers = await planoraUnitOfWork.Teachers.GetAllAsync(cancellationToken: cancellationToken);
        var lessonScheduleGroup = await planoraUnitOfWork.LessonScheduleGroups.GetAsync(l => l.Id == request.Id);
        await lessonScheduleGroupBusinesRuless.LessonScheduleGroupShouldExistWhenRequestedAsync(lessonScheduleGroup);
        var lessonSchedulesGetByGrupId = await mediator.Send(new ListAllLessonScheduleGetByGroupIdQuery { LessonScheduleGroupId = request.Id });
        var mapped = mapper.Map<LessonScheduleGroupWithLessonSchedulesGetByIdDto>(lessonScheduleGroup);
        mapped.listAllLessonScheduleGetByGroupIdDtos = lessonSchedulesGetByGrupId;
        mapped.SchoolScheduleSettingGetByIdDto = mapper.Map<SchoolScheduleSettingGetByIdDto>(setting);
        mapped.classSectionListDtos = mapper.Map<List<ClassSectionListDto>>(classSections);
        mapped.teacherListDtos = mapper.Map<List<TeacherListDto>>(teachers);
        return mapped;
    }
}


