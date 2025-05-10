using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Planora.Application.Services.Repositories;

namespace Planora.Infrastructure.Contexts
{
    public class PlanoraUserContextAccessor : UserContextAccessor, IPlanoraUserContextAccessor
    {
        public PlanoraUserContextAccessor(IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
        }

        public Guid? SchoolId => Guid.TryParse(
            _httpContextAccessor.HttpContext?.User.FindFirst("schoolId")?.Value,
            out var id) ? id : null;
    }

}
