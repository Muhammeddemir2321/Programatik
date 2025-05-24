using Core.Persistence.Repositories;
using Core.Security.Entities;
using Planora.Application.Services.Repositories;
using Planora.Persistence.Contexts;

namespace Uroflow.Persistance.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, PlanoraDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(PlanoraDbContext context) : base(context)
    {
    }
}
