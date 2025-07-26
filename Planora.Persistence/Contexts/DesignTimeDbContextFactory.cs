using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Planora.Persistence.Contexts;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PlanoraDbContext>
{
    public PlanoraDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("general.settings.json", optional: true)
            .Build();

        var builder = new DbContextOptionsBuilder<PlanoraDbContext>();
        builder.UseSqlServer(configuration.GetConnectionString("Debug"));

        return new PlanoraDbContext(builder.Options);
    }
}
