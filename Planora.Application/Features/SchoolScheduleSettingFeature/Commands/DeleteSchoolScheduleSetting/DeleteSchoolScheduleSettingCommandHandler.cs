using MediatR;
using Planora.Application.Features.SchoolScheduleSettingFeature.Rules;
using Planora.Application.Services.Repositories;

namespace Planora.Application.Features.SchoolScheduleSettingFeature.Commands.DeleteSchoolScheduleSetting
{
    public class DeleteSchoolScheduleSettingCommandHandler(
        IPlanoraUnitOfWork planoraUnitOfWork,
        SchoolScheduleSettingBusinessRules schoolScheduleSettingBusinessRules)
        : IRequestHandler<DeleteSchoolScheduleSettingCommand, bool>
    {
        public async Task<bool> Handle(DeleteSchoolScheduleSettingCommand request, CancellationToken cancellationToken)
        {
            var setting = await planoraUnitOfWork.SchoolScheduleSettings.GetAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
            await schoolScheduleSettingBusinessRules.UserShouldExistWhenRequestedAsync(setting);
            await planoraUnitOfWork.SchoolScheduleSettings.DeleteAsync(setting!, cancellationToken: cancellationToken);
            await planoraUnitOfWork.CommitAsync();
            return true;
        }
    }
}
