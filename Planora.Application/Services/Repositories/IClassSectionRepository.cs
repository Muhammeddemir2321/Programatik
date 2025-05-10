using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface IClassSectionRepository : IAsyncRepository<ClassSection>, IRepository<ClassSection>, IDynamicRepository<ClassSection>
{
}
