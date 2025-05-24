using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Uroflow.Persistance.Repositories;

public class AuthorityRepository : EfRepositoryBase<Authority, PlanoraDbContext>, IAuthorityRepository
{
    public AuthorityRepository(PlanoraDbContext context) : base(context)
    {
    }
}