using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class LectureRepository : EfRepositoryBase<Lecture, PlanoraDbContext>, ILectureRepository
{
    public LectureRepository(PlanoraDbContext context) : base(context)
    {
    }
}
