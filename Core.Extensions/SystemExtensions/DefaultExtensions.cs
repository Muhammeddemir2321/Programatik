using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions.SystemExtensions;

public static class DefaultExtensions
{
    public static WebApplicationBuilder ConfigureCustomApplicationBuilder(this WebApplicationBuilder builder, Assembly assembly)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("general.settings.json")
            .Build();
        builder.Configuration.AddConfiguration(configuration);
        var origins = configuration.GetSection("AllowedHostList").Get<string[]>();
        builder.Services.AddCors(
            policy =>
            {
                policy.AddDefaultPolicy(c =>
                {
                    c.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
        builder.Services.AddControllers(options =>
        {
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAuthentication();
        
        
        builder.Services.AddDistributedMemoryCache();

        
        builder.Services.AddHttpContextAccessor();
        ServiceTool.Create(builder.Services);

        return builder;
    }
    public static WebApplication ConfigureCustomApplication(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseCors();
        return app;
    }
}
