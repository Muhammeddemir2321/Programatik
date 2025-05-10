using Core.Persistence.Repositories;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Linq.Expressions;

namespace Planora.Persistence.Contexts;

public class PlanoraDbContext : DbContext
{
    private readonly IPlanoraUserContextAccessor _planoraUserContextAccessor;
    public PlanoraDbContext(DbContextOptions dbContextOptions, IPlanoraUserContextAccessor planoraUserContextAccessor) :base(dbContextOptions)
    {
        ServiceTool.SetDbContextOptions(dbContextOptions);
        _planoraUserContextAccessor = planoraUserContextAccessor;
    }
    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassCourseAssignment>  ClassCourseAssignments{ get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<ClassSection> ClassSections { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetSchoolIdForNewEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetSchoolIdForNewEntities()
    {
        var schoolId = _planoraUserContextAccessor.SchoolId;

        foreach (var entry in ChangeTracker.Entries<ISchoolEntity>().Where(e => e.State == EntityState.Added))
        {
            if (entry.Entity.SchoolId == Guid.Empty)
            {
                entry.Entity.SchoolId = schoolId ?? throw new UnauthorizedAccessException("SchoolId atanamadı.");
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanoraDbContext).Assembly);

        var schoolId = _planoraUserContextAccessor.SchoolId;

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISchoolEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(ISchoolEntity.SchoolId));
                var constant = Expression.Constant(schoolId);
                var equality = Expression.Equal(property, constant);
                var lambda = Expression.Lambda(equality, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

}