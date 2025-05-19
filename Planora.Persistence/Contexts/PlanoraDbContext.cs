using Core.Security.Entities;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;

namespace Planora.Persistence.Contexts;

public class PlanoraDbContext : IdentityDbContext<BaseUser, IdentityRole<Guid>, Guid>
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
    public DbSet<User> Users { get; set; }

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

        modelBuilder.Entity<Teacher>()
            .HasQueryFilter(t => t.SchoolId == schoolId);

        modelBuilder.Entity<Course>()
            .HasQueryFilter(c => c.SchoolId == schoolId);

        modelBuilder.Entity<ClassSection>()
            .HasQueryFilter(cs => cs.SchoolId == schoolId);

        modelBuilder.Entity<ClassCourseAssignment>()
            .HasQueryFilter(ca => ca.SchoolId == schoolId);

        base.OnModelCreating(modelBuilder);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanoraDbContext).Assembly);

    //    var schoolId = _planoraUserContextAccessor.SchoolId;

    //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    //    {
    //        if (typeof(ISchoolEntity).IsAssignableFrom(entityType.ClrType))
    //        {
    //            if (schoolId == null)
    //                throw new InvalidOperationException("SchoolId context üzerinden alınamadı.");
    //            var parameter = Expression.Parameter(entityType.ClrType, "e");
    //            var property = Expression.Property(parameter, nameof(ISchoolEntity.SchoolId));
    //            var constant = Expression.Constant(schoolId.Value, typeof(Guid));
    //            var equality = Expression.Equal(property, constant);
    //            var lambda = Expression.Lambda(equality, parameter);

    //            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
    //        }
    //    }

    //    base.OnModelCreating(modelBuilder);
    //}

}