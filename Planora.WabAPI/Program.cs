using Core.Extensions.SystemExtensions;
using Core.Security;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Planora.Application;
using Planora.Infrastructure;
using Planora.Persistence;
using Planora.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSecurityServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.ConfigureCustomApplicationBuilder(typeof(Program).Assembly);
builder.Services.AddIdentity<Identity, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<PlanoraDbContext>()
        .AddDefaultTokenProviders();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Security.Configuration.TokenOptions>();
builder.Services.AddCustomTokenAuth(tokenOptions);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureCustomApplication();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PlanoraDbContext>();
    await context.Database.MigrateAsync();
}
app.Run();
