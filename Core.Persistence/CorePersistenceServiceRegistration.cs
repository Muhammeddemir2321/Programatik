using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence;

public static class CorePersistenceServiceRegistration
{
    public static IServiceCollection AddCorePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}