using Planora.Application;
using Planora.Persistence;
using Core.Extensions.SystemExtensions;
using Core.Utilities.IoC;
using Planora.Persistence.Contexts;
using Planora.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.ConfigureCustomApplicationBuilder(typeof(Program).Assembly);
builder.Services.AddIdentity<BaseUser, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<PlanoraDbContext>()
        .AddDefaultTokenProviders();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureCustomApplication();
var context = ServiceTool.GetService<PlanoraDbContext>();
await context.Database.MigrateAsync();

ServiceTool.SetAppplication<WebApplication>(app);
app.Run();
