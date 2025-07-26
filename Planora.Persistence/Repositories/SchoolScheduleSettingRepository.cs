using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class SchoolScheduleSettingRepository : EfRepositoryBase<SchoolScheduleSetting, PlanoraDbContext>, ISchoolScheduleSettingRepository
{
    public SchoolScheduleSettingRepository(PlanoraDbContext context) : base(context)
    {
    }
}
