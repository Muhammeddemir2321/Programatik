using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planora.Application.Services.Repositories;
using Planora.Domain.Entities;
using System.Linq.Expressions;

namespace Planora.Persistence.Contexts;

public class PlanoraDbContext : IdentityDbContext<Identity, IdentityRole<Guid>, Guid>
{
    private readonly IPlanoraUserContextAccessor _planoraUserContextAccessor;
    public bool IsSchoolFilterEnabled { get; set; } = true;
    //public Guid? CurrentSchoolId =>
    //    IsSchoolFilterEnabled ? _planoraUserContextAccessor.SchoolId : null;
    public Guid? CurrentSchoolId => Guid.Parse("2CFAFCF1-B4B8-4547-574C-08DDBB0972BE");
    public PlanoraDbContext(DbContextOptions<PlanoraDbContext> dbContextOptions, IPlanoraUserContextAccessor planoraUserContextAccessor) : base(dbContextOptions)
    {
        _planoraUserContextAccessor = planoraUserContextAccessor;
    }
    public DbSet<School> Schools { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherUnavailable> TeacherUnavailables { get; set; }
    public DbSet<ClassTeachingAssignment> ClassTeachingAssignments { get; set; }
    public DbSet<LessonSchedule> LessonScheduleGroups { get; set; }
    public DbSet<LessonSchedule> LessonSchedules { get; set; }
    public DbSet<SchoolScheduleSetting> SchoolScheduleSettings { get; set; }
    public DbSet<LectureDistributionOption> LectureDistributionOptions { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<ClassSection> ClassSections { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuthorityOperationClaim> AuthorityOperationClaims { get; set; }
    public DbSet<IdentityOperationClaim> IdentityOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetSchoolIdForNewEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetSchoolIdForNewEntities()
    {
        //var schoolId = _planoraUserContextAccessor.SchoolId;

        foreach (var entry in ChangeTracker.Entries<ISchoolEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            if (entry.Entity.SchoolId == Guid.Empty || entry.Entity.SchoolId == null)
            {
                //entry.Entity.SchoolId = CurrentSchoolId.HasValue && CurrentSchoolId.Value != Guid.Empty ? CurrentSchoolId.Value 
                //    : throw new UnauthorizedAccessException("SchoolId atanamadı.");

                entry.Entity.SchoolId = Guid.Parse("2CFAFCF1-B4B8-4547-574C-08DDBB0972BE");

            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanoraDbContext).Assembly);


        modelBuilder.Entity<ClassSection>()
            .HasQueryFilter(cs => cs.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<ClassTeachingAssignment>()
            .HasQueryFilter(c => c.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<Lecture>()
            .HasQueryFilter(ca => ca.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<LessonSchedule>()
            .HasQueryFilter(ca => ca.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<LessonScheduleGroup>()
            .HasQueryFilter(ca => ca.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<SchoolScheduleSetting>()
            .HasQueryFilter(ca => ca.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<LectureDistributionOption>()
            .HasQueryFilter(ca => ca.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<Teacher>()
            .HasQueryFilter(t => t.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<TeacherUnavailable>()
            .HasQueryFilter(t => t.SchoolId == CurrentSchoolId);

        modelBuilder.Entity<User>()
            .HasQueryFilter(t => t.SchoolId == CurrentSchoolId);

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
