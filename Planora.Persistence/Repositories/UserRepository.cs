using Core.Persistence.Repositories;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using Planora.Persistence.Contexts;

namespace Planora.Persistence.Repositories;

public class UserRepository : EfBaseTimeStampRepositoryBase<User, PlanoraDbContext>, IUserRepository
{
    public UserRepository(PlanoraDbContext context) : base(context)
    {
    }
}
