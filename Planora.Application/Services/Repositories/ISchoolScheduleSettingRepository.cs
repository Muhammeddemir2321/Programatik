using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ISchoolScheduleSettingRepository : IAsyncRepository<SchoolScheduleSetting>, IRepository<SchoolScheduleSetting>, IDynamicRepository<SchoolScheduleSetting>
{
}
