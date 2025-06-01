using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class SchoolScheduleSettingsRepository : EfRepositoryBase<SchoolScheduleSetting, PlanoraDbContext>, ISchoolScheduleSettingRepository
{
    public SchoolScheduleSettingsRepository(PlanoraDbContext context) : base(context)
    {
    }
}
