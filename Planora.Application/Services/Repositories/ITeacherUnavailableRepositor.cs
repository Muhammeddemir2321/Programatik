using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ITeacherUnavailableRepository : IAsyncRepository<TeacherUnavailable>, IRepository<TeacherUnavailable>, IDynamicRepository<TeacherUnavailable>
{
}
