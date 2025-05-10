using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ICourseRepository : IAsyncRepository<Course>, IRepository<Course>, IDynamicRepository<Course>
{
}
