using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class LectureDistributionOptionRepository : EfRepositoryBase<LectureDistributionOption, PlanoraDbContext>, ILectureDistributionOptionRepository
{
    public LectureDistributionOptionRepository(PlanoraDbContext context) : base(context)
    {
    }
}
