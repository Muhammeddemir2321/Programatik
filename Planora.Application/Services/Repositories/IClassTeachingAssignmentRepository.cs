using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface IClassTeachingAssignmentRepository : IAsyncRepository<ClassTeachingAssignment>, IRepository<ClassTeachingAssignment>, IDynamicRepository<ClassTeachingAssignment>
{
}
