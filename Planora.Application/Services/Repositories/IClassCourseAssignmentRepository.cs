using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface IClassCourseAssignmentRepository: IAsyncRepository<ClassCourseAssignment>, IRepository<ClassCourseAssignment>, IDynamicRepository<ClassCourseAssignment>
{
}
