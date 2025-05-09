using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ISchoolRepository : IAsyncRepository<School>, IRepository<School>, IDynamicRepository<School>
{
}
