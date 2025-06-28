using AutoMapper;
using MediatR;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Features.LessonScheduleGroupFeature.Commands.UpdateLessonScheduleGroup;

public class UpdateLessonScheduleGroupIsActiveCommandHandler(
    IPlanoraUnitOfWork planoraUnitOfWork,
    IMapper mapper)
    : IRequestHandler<UpdateLessonScheduleGroupIsActiveCommand, bool>
{
    public async Task<bool> Handle(UpdateLessonScheduleGroupIsActiveCommand request, CancellationToken cancellationToken)
    {
        return await planoraUnitOfWork.ExecuteInTransactionAsync(async () =>
        {
            if (request.IsActive == true)
            {
                var aktiveLessonSecheduleGroups = await planoraUnitOfWork.LessonScheduleGroups.GetAllAsync(l => l.IsActive == true && (l.Year == request.Year && l.Semester == request.Semester), cancellationToken: cancellationToken);
                foreach (var aktiveLessonSecheduleGroup in aktiveLessonSecheduleGroups)
                {
                    aktiveLessonSecheduleGroup.IsActive = false;
                    await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(aktiveLessonSecheduleGroup, cancellationToken: cancellationToken);
                }
            }

            var mappedLessonScheduleGroup = mapper.Map<LessonScheduleGroup>(request);
            await planoraUnitOfWork.LessonScheduleGroups.UpdateAsync(mappedLessonScheduleGroup, cancellationToken: cancellationToken);
        });
    }
}
