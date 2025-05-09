using Core.Persistence.Repositories;
using Planora.Domain.Entities;

namespace Planora.Application.Services.Repositories;

public interface ILectureRepository : IAsyncRepository<Lecture>, IRepository<Lecture>
{
}
