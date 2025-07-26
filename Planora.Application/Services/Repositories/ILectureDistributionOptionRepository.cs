using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ILectureDistributionOptionRepository : IAsyncRepository<LectureDistributionOption>, IRepository<LectureDistributionOption>, IDynamicRepository<LectureDistributionOption>
{
}
