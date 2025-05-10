using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface IGradeRepository : IAsyncRepository<Grade>, IRepository<Grade>, IDynamicRepository<Grade>
{
}
