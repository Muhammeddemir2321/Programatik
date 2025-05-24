using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Planora.Application.Services.Repositories;

public interface IAuthorityRepository : IAsyncRepository<Authority>, IRepository<Authority>,IDynamicRepository<Authority> { }